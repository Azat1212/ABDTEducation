using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using YandexDisk.Client;
using YandexDisk.Client.Clients;
using YandexDisk.Client.Http;

namespace ImageService.Services
{
    public class YandexDiskService
    {
        private readonly ILogger<YandexDiskService> _logger;
        private readonly YandexDiskConfig _yandexDiskConfig;
        private readonly IDiskApi _diskApi;

        public YandexDiskService(ILogger<YandexDiskService> logger, IOptions<YandexDiskConfig> yandexDiskConfig)
        {
            _logger = logger;
            _yandexDiskConfig = yandexDiskConfig.Value;
            _diskApi = new DiskHttpApi(_yandexDiskConfig.AccessToken);
        }
        public string UploadFile(IFormFile file)
        {
            var fileName = GetFileName(file);
            var filePath = Path.Combine(_yandexDiskConfig.BasePath, fileName);

            //Upload file from local
            _diskApi.Files.UploadFileAsync(
                path: filePath,
                overwrite: false,
                localFile: file.FileName,
                cancellationToken: CancellationToken.None);

            return filePath;
        }

        private static string GetFileName(IFormFile file)
        {
            var fileName = Path.GetFileNameWithoutExtension(file!.FileName);

            var fileExtension = Path.GetExtension(file!.FileName);

            var imageName = $"image_{fileName}_{DateTime.UtcNow}";

            using var md5 = MD5.Create();

            var hashBytes = md5.ComputeHash(Encoding.ASCII.GetBytes(imageName));

            return BitConverter.ToString(hashBytes) + fileExtension;
        }
    }
}
