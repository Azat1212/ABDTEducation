using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ProductService.Models;

namespace ProductService.Interfaces
{
    public interface IProductService
    {
        Task<Product> GetByProductId(Guid productId);
        Task<IEnumerable<Product>> GetAll();

        Task Create(string name, string description);
        Task Update(Guid productId, string name, string description);
        Task Delete(Guid productId);
    }
}
