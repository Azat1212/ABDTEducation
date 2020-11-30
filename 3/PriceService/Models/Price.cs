using System;

namespace PriceService.Models
{
    public class Price
    {
        public Guid ProductId { get; set; }
        public double Retail { get; set; }
        public double Cost { get; set; }
        public double Current { get; set; }
        public bool IsLast { get; set; }
    }
}
