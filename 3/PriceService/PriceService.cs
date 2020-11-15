using System;
using System.Collections.Generic;
using System.Linq;

namespace PriceService
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
