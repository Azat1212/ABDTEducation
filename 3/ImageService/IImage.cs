using System.Collections.Generic;

namespace ImageService
{
    public interface IImage
    {
        public IEnumerable<Image> GetAll();
    }
}
