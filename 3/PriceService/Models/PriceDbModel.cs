

using System;
using Repository;

namespace PriceService.Models
{
    public class PriceDbModel : BaseEntity
    {
        public PriceDbModel(Guid productId, double retail, double cost, double current) : base()
        {
            ProductId = productId;
            Retail = retail;
            Cost = cost;
            Current = current;
        }

        public Guid ProductId { get; set;}
        public double Retail { get; set; }
        public double Cost { get; set; }
        public double Current { get; set; }
        public bool IsLast { get; set; }
    }
}
