using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PriceService.Models;
using Repository;

namespace PriceService.Repositories
{
    public interface IPriceRepository : IBaseRepository<PriceDbModel>
    {
        Task<IEnumerable<PriceDbModel>> GetByProductId(Guid id, bool lasted = true);
        Task<bool> UpdateByProductId(Guid id, double price);
        Task<bool> DeleteByProductId(Guid id);
    }
}
