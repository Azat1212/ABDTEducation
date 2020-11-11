using System;
using System.Collections.Generic;
using System.Linq;

namespace ImageService
{
    public class ImageService : IImage
    {
        private static readonly string[] Extension = new[]
        {
            "JPEG", "GIF", "PNG", "SVG", "RAW"
        };

        public IEnumerable<Image> GetAll()
        {
            var rng = new Random();
            return Enumerable.Range(1, 2).Select(index => new Image
                {
                    Date = DateTime.Now.AddDays(index),
                    Extension = Extension[rng.Next(Extension.Length)],
                    Resolution = new Tuple<int, int>(rng.Next(1000, 3000), rng.Next(1000, 3000)),
                    Size = rng.Next(800, 15000)
                })
                .ToArray();
        }
    }
}
