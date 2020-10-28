using System.Collections.Generic;

namespace ProductService.Interfaces
{
    public interface IProduct
    {
        public IEnumerable<IProduct> GetAll();
    }
}
