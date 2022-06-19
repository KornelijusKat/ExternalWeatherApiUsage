using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WeatherAPIStuff.Objects
{
    public class CWeather
    {
        public Guid Id { get; set; }
        public int Temperature { get; set; }
        public string Country { get; set; }
        public string Region { get; set; }
        public string Language { get; set; }

        public CWeather(int temperature, string country, string region, string language)
        {
            Id = Guid.NewGuid();
            Temperature = temperature;
            Country = country;
            Region = region;
            Language = language;
        }
    }
}
