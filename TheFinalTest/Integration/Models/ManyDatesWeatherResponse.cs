using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TheFinalTest.Integration.Models
{
    public class ManyDatesWeatherResponse
    {
        public List[] List { get; set; }
        public City City { get; set; }
    }

    public class List
    {
        public DateTime Dt_txt { get; set; }
        public Main Main { get; set; }
    }     
    public class City
    {
        public string Name { get; set; }
    }    
}
