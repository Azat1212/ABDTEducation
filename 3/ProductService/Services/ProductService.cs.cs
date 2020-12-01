using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProductService.Interfaces;
using ProductService.Models;

namespace ProductService.Services
{
    public class ProductService : IProductService
    {
        public Task<IEnumerable<Product>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<Product> GetByProductId(Guid productId)
        {
            throw new NotImplementedException();
        }

        public Task Create(string name, string description)
        {
            throw new NotImplementedException();
        }

        public Task Update(Guid productId)
        {
            throw new NotImplementedException();
        }

        public Task Delete(Guid productId)
        {
            throw new NotImplementedException();
        }
    }
}
