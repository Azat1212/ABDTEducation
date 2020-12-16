using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TheFinalTest.Integration.Clients;
using TheFinalTest.Models;

namespace TheFinalTest.Services
{
    public class WeatherService : IWeatherService
    {
        private readonly IOpenWeatherMapClient _client;
        private readonly string _token = "2caaefdcafd242c8eae17b5f7dc6337a";
        
        public WeatherService(IOpenWeatherMapClient client)
        {
            _client = client;
        }

        public async Task<TemperatureResponse> GetTemperatureResponseAsync(string city, MetricEnum metric)
        {
            var apiResponse = await _client.GetCurrentWeatherAsync(city, _token);

            var temperature = apiResponse.Main.Temp;
            if (metric == MetricEnum.celsius)
            {
                temperature -= 273;
                temperature = Math.Round(temperature, 2);
            }

            return new TemperatureResponse
            {
                City = apiResponse.Name,
                Metric = metric.ToString(),
                Temperature = temperature
            };
        }
    }
}
