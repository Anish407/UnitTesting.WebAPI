using Microsoft.AspNetCore.Http.Features;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using UnitTesting.WebAPI.Model;

namespace UnitTesting.WebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }

        [HttpGet("GetWeatherForecast")]
        public ActionResult<IEnumerable<WeatherForecast>> GetWeatherForecast(string id)
        {


            if (id == null) return NotFound("No Data Found");

            return Ok(Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            })
            .ToArray());
        }

        [HttpGet("GetData")]
        public ActionResult<DataModel> GetData()
        {
            var ip = HttpContext.Connection.RemoteIpAddress;
            string path = HttpContext.Request.Path;
            IPAddress remoteIp = HttpContext?.Features?.Get<IHttpConnectionFeature>()?.RemoteIpAddress
                 ?? throw new Exception("Error");

            return Ok(new DataModel
            {
                Path = path,
                Ip = remoteIp.ToString()
            });
        }
    }
}