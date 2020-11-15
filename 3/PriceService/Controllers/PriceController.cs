using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace PriceService.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PriceController : ControllerBase
    {
        
        private readonly ILogger<PriceController> _logger;

        public PriceController(ILogger<PriceController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IEnumerable<Price> GetAll()
        {
            var prices = new global::PriceService.PriceService();
            return prices.GetAll();
        }
    }
}