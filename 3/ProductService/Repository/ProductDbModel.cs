using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Repository;

namespace ProductService.Repository
{
    public class ProductDbModel : BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
