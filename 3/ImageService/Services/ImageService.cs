using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ImageService.Entities;
using Microsoft.EntityFrameworkCore;

namespace ImageService.Services
{
    public class ImageService : IImageService
    {
        private readonly ImageContext _imageContext;

        public ImageService(ImageContext imageContext)
        {
            _imageContext = imageContext;
        }

    public async Task<IEnumerable<ImageEntity>> GetAll()
        {
            return await _imageContext.Images.ToListAsync();
        }
    }
}
