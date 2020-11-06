using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProductService.Interfaces;
using ProductService.Models;

namespace ProductService.Services
{
    public class PriceService : IPrice
    {
        private static readonly string[] Types = new[]
        {
            "Purchasing", "Selling", "Recommended", "Promotional"
        };
        public IEnumerable<Price> GetAll()
        {
            var rng = new Random();
            return Enumerable.Range(1, Types.Length).Select(index => new Price
                {
                    Type = Types[index - 1],
                    Value = rng.Next(40, 55)
                })
                .ToArray();
        }
    }
}
