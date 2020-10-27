using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace ImageService.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ImageController : ControllerBase
    {
        private static readonly string[] Extension = new[]
        {
            "JPEG", "GIF", "PNG", "SVG", "RAW"
        };

        private readonly ILogger<ImageController> _logger;

        public ImageController(ILogger<ImageController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IEnumerable<Image> GetAll()
        {
            var rng = new Random();
            return Enumerable.Range(1, 5).Select(index => new Image
            {
                Date = DateTime.Now.AddDays(index),
                Extension = Extension[rng.Next(Extension.Length)],
                Resolution = new Tuple<int, int>(rng.Next(1000,3000), rng.Next(1000, 3000)),
                Size = rng.Next(800, 15000)
            })
            .ToArray();
        }
    }
}
