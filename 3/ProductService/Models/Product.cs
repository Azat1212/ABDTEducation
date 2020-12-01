using System;
using System.Collections.Generic;

namespace ProductService.Models
{
    public class Product
    {
        public Product(string name, string description)
        {
            Name = name;
            Description = description;
        }

        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public IEnumerable<Image> Images { get; set; }

        public IEnumerable<Price> Prices { get; set; }
    }
}
