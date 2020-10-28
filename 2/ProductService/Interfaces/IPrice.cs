using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProductService.Models;

namespace ProductService.Interfaces
{
    public interface IPrice
    {
        public IEnumerable<Price> GetAll();
    }
}
