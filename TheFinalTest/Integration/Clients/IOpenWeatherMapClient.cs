using Refit;
using System.Threading.Tasks;
using TheFinalTest.Integration.Models;

namespace TheFinalTest.Integration.Clients
{
    public interface IOpenWeatherMapClient
    {
        [Get("/data/2.5/weather?q={cityName}&appid={apiKey}")]
        public Task<CurrentWeatherResponse> GetCurrentWeatherAsync(string cityName, string apiKey);

        [Get("/data/2.5/forecast?q={cityName}&appid={apiKey}")]
        public Task<ManyDatesWeatherResponse> GetForecastWeatherAsync(string cityName, string apiKey);
    }
}
