using System.Collections.Generic;
using ProductService.Interfaces;

namespace ProductService.Models
{
    public class Product
    {
        public IEnumerable<Image> Images { get; set; }

        public IEnumerable<Price> Prices { get; set; }
        public string Type { get; set; }
    }
}
