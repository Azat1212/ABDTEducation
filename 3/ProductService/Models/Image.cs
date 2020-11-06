using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductService.Models
{
    public class Image
    {
        public DateTime Date { get; set; }

        public string Extension { get; set; }

        public Tuple<int, int> Resolution { get; set; }

        public int Size { get; set; }
    }
}
