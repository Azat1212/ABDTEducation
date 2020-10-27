using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace PriceService.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PriceController : ControllerBase
    {
        private static readonly string[] Types = new[]
        {
            "Purchasing", "Selling", "Recommended", "Promotional"
        };

        private readonly ILogger<PriceController> _logger;

        public PriceController(ILogger<PriceController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IEnumerable<Price> GetAll()
        {
            var rng = new Random();
            return Enumerable.Range(1, Types.Length ).Select(index => new Price
            {
                Type = Types[index - 1],
                Value = rng.Next(40, 55)
            })
            .ToArray();
        }
    }
}
