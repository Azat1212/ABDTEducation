using System.Collections.Generic;

namespace PriceService
{
    public interface IPrice
    {
        public IEnumerable<Price> GetAll();
    }
}
