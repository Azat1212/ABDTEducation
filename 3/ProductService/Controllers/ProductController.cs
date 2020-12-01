using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ProductService.Clients;
using ProductService.Interfaces;
using ProductService.Models;

namespace ProductService.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;
        private readonly ILogger<ProductController> _logger;

        public ProductController(IProductService productService, ILogger<ProductController> logger)
        {
            _productService = productService;
            _logger = logger;
        }

        [HttpGet]
        public async Task<IEnumerable<Product>> GetAll()
        {
           return await _productService.GetAll();
        }

        [HttpGet("{productId}")]
        public async Task<Product> GetByProductId(Guid productId)
        {
            return await _productService.GetByProductId(productId);
        }

        [HttpPost]
        public async Task Create(string name, string description)
        {
            await _productService.Create(name, description);
        }
        
        [HttpPut]
        public async Task Update(Guid productId)
        {
            await _productService.Update(productId);
        }
        
        [HttpDelete]
        public async Task Delete(Guid productId)
        {
            await _productService.Delete(productId);
        }
    }
}
