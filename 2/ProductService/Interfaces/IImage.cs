using System.Collections.Generic;
using ProductService.Models;

namespace ProductService.Interfaces
{
    public interface IImage
    {
        public IEnumerable<Image> GetAll();
    }
}
