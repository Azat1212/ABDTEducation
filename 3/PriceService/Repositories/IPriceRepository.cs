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
      //  Task<IEnumerable<PriceDbModel>> GetAll();
    }
}
