using System.Collections.Generic;
using ImageService.Models;

namespace ImageService.Interfaces
{
    public interface IImage
    {
        public IEnumerable<Image> GetAll();
    }
}
