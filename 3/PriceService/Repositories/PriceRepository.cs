using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;
using PriceService.Models;
using Repository;

namespace PriceService.Repositories
{
    public class PriceRepository : BaseRepository<PriceDbModel>, IPriceRepository
    {

        public PriceRepository(IOptions<PriceDbOptions> dbOptions) : base(dbOptions)
        {
        }

    }

}
