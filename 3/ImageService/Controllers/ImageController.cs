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

        [HttpGet]
        public async Task<IEnumerable<Image>> Get()
        {
            var imageEntities = await _imageService.GetAll();
            return _mapper.Map<IEnumerable<Image>>(imageEntities);
        }
    }
}