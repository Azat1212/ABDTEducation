using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using ImageService.Interfaces;
using ImageService.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using RestSharp;

namespace ImageService.Services
{
    public class YandexDiskService : IYandexDiskService
    {
        private readonly ILogger<YandexDiskService> _logger;
        private readonly YandexDiskConfig _yaConfig;
        private readonly IPoligonClient _yaClient;

        public YandexDiskService(
            IOptions<YandexDiskConfig> yandexDiskConfig,
            IPoligonClient yandexPoligonClient,
            ILogger<YandexDiskService> logger)
        {
            _logger = logger;
            _yaConfig = yandexDiskConfig.Value;
            _yaClient = yandexPoligonClient;
        }

        public async Task<string> UploadFile(IFormFile file)
        {
            var fileName = GetFileName(file);
            var fileYaPath = Path.Combine(_yaConfig.BasePath, fileName);

            await UploadToYaDisk(fileYaPath, file);
            await PublishToYaDisk(fileYaPath);

            return fileYaPath;
        }

        public string GetFileName(IFormFile file)
        {
            var fileName = Path.GetFileNameWithoutExtension(file!.FileName);

            var fileExtension = Path.GetExtension(file!.FileName);

            var imageName = $"image_{fileName}_{DateTime.UtcNow}";

            using var md5 = MD5.Create();

            var hashBytes = md5.ComputeHash(Encoding.ASCII.GetBytes(imageName));

            return BitConverter.ToString(hashBytes) + fileExtension;
        }

        private async Task UploadToYaDisk(string filePath, IFormFile file)
        {
            try
            {
                var uploadLink = await _yaClient.GetHref(filePath, _yaConfig.AccessToken);

                var client = new RestClient(uploadLink.Href);
                var request = new RestRequest(Method.PUT);

                request.AddHeader("Authorization", _yaConfig.AccessToken);

                var ms = new MemoryStream();

                file.CopyTo(ms);
                var fileBytes = ms.ToArray();
                string s = Convert.ToBase64String(fileBytes);


                request.AddFile("file", fileBytes /*File.ReadAllBytes(file)*/, "");
                client.Execute(request);
            }
            catch (Exception e)
            {
                string message = "Failed to upload file to Yandex Disk.";

                _logger.LogError(message, e);
                throw new InvalidOperationException(message, e);
            }
        }

        private async Task PublishToYaDisk(string filePath)
        {
            try
            {
                _yaClient.PublishFile(filePath, _yaConfig.AccessToken);

            }
            catch (Exception e)
            {
                string message = "Failed to publish file to Yandex Disk.";

                _logger.LogError(message, e);
                throw new InvalidOperationException(message, e);
            }
        }
    }
}