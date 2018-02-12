using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using NLog;

namespace ASampleWeb.Controllers
{
    [Route("api/[controller]")]
    public class SampleDataController : Controller
    {
        private static Logger _logger = LogManager.GetCurrentClassLogger();
        public SampleDataController()
        {
            _logger.Info("SampleDataController started.");

        }
        private static string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        [HttpGet("[action]")]
        public IEnumerable<WeatherForecast> WeatherForecasts()
        {
            _logger.Info("WeatherForecasts requested");
            var rng = new Random();
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                DateFormatted = DateTime.Now.AddDays(index).ToString("d"),
                TemperatureC = rng.Next(-20, 55),
                Summary = Summaries[rng.Next(Summaries.Length)]
            });
        }
        [HttpGet("exception")]
        public async Task<IActionResult> Get(int id)
        {
            var x = 100;

            try
            {
                var i = 200 / (x - x);
            } catch (Exception exc)
            {
                _logger.Error(exc, "Something bad happened");
            }
            
            return Ok();
        }

        public class WeatherForecast
        {
            public string DateFormatted { get; set; }
            public int TemperatureC { get; set; }
            public string Summary { get; set; }

            public int TemperatureF
            {
                get
                {
                    return 32 + (int)(TemperatureC / 0.5556);
                }
            }
        }
    }
}
