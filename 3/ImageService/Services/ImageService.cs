using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using ImageService.Entities;
using Microsoft.EntityFrameworkCore;
using System.Web.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.FileProviders;

namespace ImageService.Services
{
    public class ImageService : IImageService
    {
        private readonly ImageContext _imageContext;
        private readonly YandexDiskService _yandexDiskService;

        public ImageService(ImageContext imageContext)
        {
            _imageContext = imageContext;
        }

        public async Task<IEnumerable<ImageEntity>> GetAll()
        {
            var images = await _imageContext.Images
            .Where(i => i.IsDeleted == false)
            .ToListAsync();

            if (images == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
            return images;
        }
        public async Task<ImageEntity> Get(Guid id)
        {
            var image = await _imageContext.Images
                .FirstOrDefaultAsync(i => i.Id == id && i.IsDeleted == false);

            if (image == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
            return image;
        }

        public async Task<IEnumerable<ImageEntity>> GetByProductId(Guid productId)
        {
            var image = await _imageContext.Images
                .Where(i => i.ProductId == productId && i.IsDeleted == false)
                .ToListAsync();

            if (image == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }

            return image;
        }

        public async Task SaveImages(Guid productId, IEnumerable<Uri> uris)
        {
            foreach (var image in uris)
            {
               await SaveImage(productId, image);
            }
        }

        public async Task SaveImage(Guid productId, Uri uri)
        {
            var productImage = new ImageEntity();

            productImage.Url = uri.ToString();
            productImage.Id = Guid.NewGuid();
            productImage.ProductId = productId;
            productImage.CreatedBy = Guid.NewGuid();
            productImage.LastSavedBy = Guid.NewGuid();
            productImage.CreatedDate = DateTime.UtcNow;
            productImage.LastSavedDate = DateTime.UtcNow;

            await _imageContext.Images.AddAsync(productImage);
            await _imageContext.SaveChangesAsync();
        }

        public async Task SaveImage(Guid productId, IFormFile file)
        {
            var uploadedLink = _yandexDiskService.UploadFile(file);

            var productImage = new ImageEntity();

            productImage.Url = uploadedLink;
            productImage.Id = Guid.NewGuid();
            productImage.ProductId = productId;
            productImage.CreatedBy = Guid.NewGuid();
            productImage.LastSavedBy = Guid.NewGuid();
            productImage.CreatedDate = DateTime.UtcNow;
            productImage.LastSavedDate = DateTime.UtcNow;

            await _imageContext.Images.AddAsync(productImage);
            await _imageContext.SaveChangesAsync();
        }

        public async Task UpdateImages(Guid productId, IEnumerable<Image> images)
        {
            foreach (var image in images)
            {
               await UpdateImage(productId, image);
            }
        }

        public async Task UpdateImage(Guid productId, Image image)
        {
            var imageDb = _imageContext.Images
                .Where(i => i.ProductId == productId
                            && i.Id == image.Id
                            && i.IsDeleted == false)
                .FirstOrDefault();

            if (imageDb == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }

            imageDb.Url = image.Url;
            imageDb.LastSavedDate = DateTime.UtcNow;
            imageDb.LastSavedBy = Guid.NewGuid();

            await _imageContext.SaveChangesAsync();
        }

        public async Task DeleteImages(Guid productId)
        {
            var image = _imageContext.Images
                .Where(i => i.ProductId == productId && i.IsDeleted == false)
                .AsEnumerable()
                .Select(i =>
                {
                    i.IsDeleted = true;
                    i.LastSavedDate = DateTime.UtcNow;
                    i.LastSavedBy = Guid.NewGuid();
                    return i;
                });

            await _imageContext.SaveChangesAsync();

            if (image == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
        }

        public async Task DeleteImage(Guid id)
        {
            var image = _imageContext.Images
                .Where(i => i.Id == id && i.IsDeleted == false)
                .AsEnumerable()
                .Select(i =>
                {
                    i.IsDeleted = true;
                    i.LastSavedDate = DateTime.UtcNow;
                    i.LastSavedBy = Guid.NewGuid();
                    return i;
                });
            await _imageContext.SaveChangesAsync();

            if (image == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }

        }

    }
}
