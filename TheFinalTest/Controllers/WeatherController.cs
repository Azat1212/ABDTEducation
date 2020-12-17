using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TheFinalTest.Models;
using TheFinalTest.Services;

namespace TheFinalTest.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherController : ControllerBase
    {
        private readonly ILogger<WeatherController> _logger;
        private readonly IWeatherService _service;

        public WeatherController(ILogger<WeatherController> logger, IWeatherService service)
        {
            _service = service;
            _logger = logger;
        }

        [HttpGet("temperature/{cityName}/{metric}")]
        public Task<TemperatureResponse> GetTemperature(string cityName, MetricEnum metric)
        {
            return _service.GetTemperatureResponseAsync(cityName, metric);
        }

        [HttpGet("wind/{cityName}")]
        public Task<WindResponse> GetWind(string cityName)
        {
            return _service.GetWindResponseAsync(cityName);
        }

        [HttpGet("weather/{cityName}/future/{metric}")]
        public Task<WeatherResponse> GetWeather(string cityName, MetricEnum metric)
        {
            return _service.GetWeatherResponseAsync(cityName, metric);
        }
    }
}
