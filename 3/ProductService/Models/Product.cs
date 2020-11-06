using System;
using System.Collections.Generic;

namespace ProductService.Models
{
    public class Product
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public IEnumerable<Image> Images { get; set; }

        public IEnumerable<Price> Prices { get; set; }
        public string Type { get; set; }
    }
}
