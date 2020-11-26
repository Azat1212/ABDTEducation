using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ImageService.Entities;

namespace ImageService.Services
{
    public interface IImageService
    {
        Task<IEnumerable<ImageEntity>> GetAll();
    }
}
