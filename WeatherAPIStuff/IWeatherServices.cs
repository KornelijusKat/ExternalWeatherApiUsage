using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WeatherAPIStuff
{
   public interface IWeatherServices
    {
        IEnumerable<string> GetINformation(string body);
    }
}
