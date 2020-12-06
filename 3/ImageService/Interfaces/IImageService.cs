using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ImageService.Entities;
using ImageService.Models;
using Microsoft.AspNetCore.Http;

namespace ImageService.Interfaces
{
    public interface IImageService
    {
        Task<IEnumerable<ImageEntity>> GetAll();
        Task<IEnumerable<ImageEntity>> GetByProductId(Guid productId);
        Task<ImageEntity> Get(Guid id);

        Task SaveImages(Guid productId, IEnumerable<Uri> images);
        Task SaveImage(Guid productId, Uri uri);
        Task SaveImage(Guid productId, IFormFile file);

        Task UpdateImages(Guid productId, IEnumerable<Image> images);
        Task UpdateImage(Guid productId, Image image);

        Task DeleteImages(Guid productId);
        Task DeleteImage(Guid id);
    }
}
