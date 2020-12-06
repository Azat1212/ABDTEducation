using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace ImageService.Interfaces
{
    public interface IYandexDiskService
    {
        public Task<string> UploadFile(IFormFile file);

        public string GetFileName(IFormFile file);

    }
}
