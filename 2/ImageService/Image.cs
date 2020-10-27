using System;

namespace ImageService
{
    public class Image
    {
        public DateTime Date { get; set; }

        public string Extension { get; set; }

        public Tuple<int, int> Resolution { get; set; }

        public int Size { get; set; }
    }
}
