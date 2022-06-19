using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using WeatherAPIStuff.Weather_Services;
using static System.Net.WebRequestMethods;

namespace WeatherAPIStuff.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherController : Controller
    {
        public ILogger<WeatherController> _logger;
        private readonly IWeatherServices _weathers;
        public HttpClient Clienta = new HttpClient();
        public WeatherController(ILogger<WeatherController> logger, IWeatherServices weathers)
        {
            _logger = logger;
            _weathers = weathers;
        }
        [HttpGet("getter")]
        public ActionResult<IEnumerable<string>> Indexs([FromQuery]string city)
        {

            WeatherServices _Weather = new WeatherServices(Clienta);
            _logger.LogInformation(city);
            var extApi = _Weather.HttpClientExtension(city);
            var logInfo = _weathers.GetINformation(extApi.Result.ToString());
            var counted = logInfo.Count();
            if (counted == 0)
            {
                return NotFound();
            }
            foreach (var x in logInfo)
            {
                _logger.LogInformation(x);
            }
            return Ok(logInfo);
        }
    }
}
