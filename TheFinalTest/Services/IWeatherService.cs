using System.Collections.Generic;
using System.Threading.Tasks;
using TheFinalTest.Models;

namespace TheFinalTest.Services
{
    public interface IWeatherService
    {
        Task<TemperatureResponse> GetTemperatureResponseAsync(string city, MetricEnum metric);
        Task<WindResponse> GetWindResponseAsync(string city);
        Task<WeatherResponse> GetWeatherResponseAsync(string city, MetricEnum metric);
    }
}