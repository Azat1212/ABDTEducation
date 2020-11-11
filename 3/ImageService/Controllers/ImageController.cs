using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace ImageService
{
    [ApiController]
    [Route("[controller]")]
    public class ImageController : ControllerBase
    {
        
        private readonly ILogger<ImageController> _logger;

        public ImageController(ILogger<ImageController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IEnumerable<Image> GetAll()
        {
            var images = new ImageService();
            return images.GetAll();
        }
    }
}