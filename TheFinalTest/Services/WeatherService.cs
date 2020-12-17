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

            temperature = (metric == MetricEnum.celsius) ? FahrenheitToCelsius(temperature) : temperature;

            return new TemperatureResponse
            {
                City = apiResponse.Name,
                Metric = metric.ToString(),
                Temperature = temperature
            };
        }
        public async Task<WindResponse> GetWindResponseAsync(string city)
        {
            var apiResponse = await _client.GetCurrentWeatherAsync(city, _token);
            var windDirection = apiResponse.Wind.Deg switch
            {
                > 338 and <= 360 or >= 0 and <= 23 => DirectionEnum.North,
                > 23 and <= 68   => DirectionEnum.NorthEast,
                > 68 and <= 113  => DirectionEnum.East,
                > 113 and <= 158 => DirectionEnum.SouthEast,
                > 158 and <= 203 => DirectionEnum.South,
                > 203 and <= 248 => DirectionEnum.SouthWest,
                > 248 and <= 293 => DirectionEnum.West,
                > 293 and <= 338 => DirectionEnum.NorthWest
            };

            return new WindResponse
            {
                City = apiResponse.Name,
                Direction = windDirection.ToString(),
                Speed = apiResponse.Wind.Speed
            };
        }
        public async Task<WeatherResponse> GetWeatherResponseAsync(string city, MetricEnum metric)
        {
            var apiResponse = await _client.GetForecastWeatherAsync(city, _token);
            
            return new WeatherResponse
            {
                Days = apiResponse.List.Select(x => new Days
                    {
                        City = apiResponse.City.Name,
                        Date = x.Dt_txt,
                        Temperature = (metric == MetricEnum.celsius) ? FahrenheitToCelsius(x.Main.Temp) : x.Main.Temp,
                        TemperatureMetric = metric.ToString()
                    }
                    ).ToList()
            };
        }

        private double FahrenheitToCelsius(double temperature)
        {
                temperature -= 273;
                return Math.Round(temperature, 2);
        }


    }
}
