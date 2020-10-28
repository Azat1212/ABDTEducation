using System.Collections.Generic;
using ProductService.Interfaces;

namespace ProductService.Models
{
    public class Product
    {
        public IEnumerable<Image> Images;

        public IEnumerable<Price> Prices;

        public string Type { get; set; }

        //TODO: добавить полей
    }
}
