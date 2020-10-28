using System.Collections.Generic;
using System.Linq;
using ProductService.Interfaces;
using ProductService.Models;

namespace ProductService.Services
{
    public class ProductService
    {
        public ProductService(IImage imageService, IPrice priceService)
        {
            _imageService = imageService;
            _priceService = priceService;
        }

        private static readonly string[] Types = new[]
        {
            "fruits", "vegetables", "meats", "milk", "coffee"
        };

        private IImage _imageService { get; set; }
        private IPrice _priceService { get; set; }

        public IEnumerable<Product> GetAll()
        {
            //var result = new List<Product>();
            //result.Add(new Product
            //{
            //    Images = _imageService.GetAll(),
            //    Prices = _priceService.GetAll()


            //});
            return Enumerable.Range(1, Types.Length).Select(index => new Product
            {
                Type = Types[index-1],
                Images = _imageService.GetAll(),
                Prices = _priceService.GetAll()

            })
                .ToArray();
            //return result;
        }
    }
}
