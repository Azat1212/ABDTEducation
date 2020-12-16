using System.Threading.Tasks;
using TheFinalTest.Models;

namespace TheFinalTest.Services
{
    public interface IWeatherService
    {
        Task<TemperatureResponse> GetTemperatureResponseAsync(string city, MetricEnum metric);
    }
}