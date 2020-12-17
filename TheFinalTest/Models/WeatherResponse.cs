using System;
using System.Collections.Generic;

namespace TheFinalTest.Models
{
    public class WeatherResponse
    {
        public ICollection<Days> Days;
    }

    public class Days
    {
        public DateTime Date;
        public string City;
        public double Temperature;
        public string TemperatureMetric;
    }
}
