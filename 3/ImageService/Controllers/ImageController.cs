using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ImageService.Services;

namespace ImageService
{
    [ApiController]
    [Route("[controller]")]
    public class ImageController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IImageService _imageService;
        private readonly ILogger<ImageController> _logger;

        public ImageController(IMapper mapper, IImageService imageService, ILogger<ImageController> logger)
        {
            _mapper = mapper;
            _imageService = imageService;
            _logger = logger;
        }

        [HttpGet] public async Task<IEnumerable<Image>> GetAll()
        {
            var imageEntities = await _imageService.GetAll();
            return _mapper.Map<IEnumerable<Image>>(imageEntities);
        }
        
        [HttpGet("{productId}")] public async Task<IEnumerable<Image>> GetByProductId(Guid productId)
        {
            var imageEntities = await _imageService.GetByProductId(productId);
            return _mapper.Map<IEnumerable<Image>>(imageEntities);
        }

        [HttpGet("{id}")] public async Task<Image> Get(Guid id)
        {
            var imageEntity = await _imageService.Get(id);
            return _mapper.Map<Image>(imageEntity);
        }

        [HttpPost]
        public async Task CreateImages(Guid productId, IEnumerable<Image> images)
        {
            var imagesEntity = _mapper.Map<IEnumerable<Image>>(images);
            await _imageService.SaveImages(productId, imagesEntity);
        }

        [HttpPost("{id}")]
        public async Task CreateImage(Guid productId, Image image)
        {
            var imageEntity = _mapper.Map<Image>(image);
            await _imageService.SaveImage(productId, imageEntity);
        }

        [HttpPut]
        public async Task UpdateImages(Guid productId, IEnumerable<Image> images)
        {
            var imagesEntity = _mapper.Map<IEnumerable<Image>>(images);
            await _imageService.UpdateImages(productId, imagesEntity);
        }

        [HttpPut("{id}")]
        public async Task UpdateImage(Guid productId, Image image)
        {
            var imageEntity = _mapper.Map<Image>(image);
            await _imageService.UpdateImage(productId, imageEntity);
        }

        [HttpDelete]
        public async Task DeleteImages(Guid productId)
        {
            await _imageService.DeleteImages(productId);
        }
        
        [HttpDelete("{id}")]
        public async Task DeleteImage(Guid guid)
        {
            await _imageService.DeleteImage(guid);
        }

    }
}