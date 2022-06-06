using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using net01_API.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace net01_API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static List<string> Summaries = new List<string>
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };
        private static List<Weather> Weather = new();

        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IEnumerable<WeatherForecast> Get()
        {
            var rng = new Random();
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = rng.Next(-20, 55),
                Summary = Summaries[rng.Next(Summaries.Count)]
            })
            .ToArray();
        }

        [HttpGet("GetEveryOtherWeather")]
        public string[] GetInformation()
        {
            return Summaries.Where((x, y) => y % 2 == 0).ToArray();
        }

        [HttpGet("GetWeatherByIndex/{index}")]
        public string GetWeatherByIndex([FromRoute] int index)
        {
            return Summaries[index];
        }

        [HttpPost("AddNewWeather")]
        public IEnumerable<string> AddnewWeather([FromBody] string weather)
        {
            Summaries.Add(weather);
            return Summaries;
        }


        [HttpPost("AddNewWeatherObj")]
        public IEnumerable<Weather> AddnewWeatherObj([FromBody] Weather weather)
        {
            Weather.Add(weather);
            return Weather;
        }

        [HttpPut("UpdateWeather")]
        public IEnumerable<Weather> UpdateWeather([FromBody] Weather weather)
        {
            var weatherToUpdate = Weather.First(x => x.Id == weather.Id);
            weatherToUpdate.Wind = weather.Wind;
            weatherToUpdate.WindSpeed = weather.WindSpeed;
            weatherToUpdate.Temperature = weather.Temperature;
            return Weather;
        }
    }
}
