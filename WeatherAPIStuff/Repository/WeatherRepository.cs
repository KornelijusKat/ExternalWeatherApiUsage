using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WeatherAPIStuff.Objects;

namespace WeatherAPIStuff.Repository
{
    public class WeatherRepository : IWeatherServices
    {
        private readonly ILogger<WeatherRepository> _logger;

        private readonly CWeatherDbContext _context;
        public WeatherRepository(CWeatherDbContext context)
        {
            _context = context;
        }
        public IEnumerable<string> GetINformation(string body)
        { 

           
            var Deserialized = JsonConvert.DeserializeObject<Root>(body);
            var Listas = new List<string>();
            Listas.Add(Convert.ToString(Deserialized.current.temperature));
            Listas.Add(Deserialized.location.country);
            Listas.Add(Deserialized.location.region);
            Listas.Add(Deserialized.request.language);
            var city = new CWeather(Deserialized.current.temperature, Deserialized.location.country, Deserialized.location.region, Deserialized.request.language);
            _context.CWeathers.Add(city);
            _context.SaveChanges();
            return Listas;
        }
    }
}
