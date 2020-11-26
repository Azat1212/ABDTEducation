using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ImageService
{
    public class Image
    {
        public Guid Id => Guid.NewGuid();
        public Guid ProductId => Guid.NewGuid();
        public string Url => $"https://images/{new Random().Next()}.jpg";
    }
}
