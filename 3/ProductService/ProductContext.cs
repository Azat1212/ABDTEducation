using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ProductService.Repository;

namespace ProductService
{
    public class ProductContext : DbContext
    {
        public DbSet<ProductDbModel> Product { get; set; }

        public ProductContext(DbContextOptions options) : base()
        {
            Database.EnsureCreated();
        }
    }
}
