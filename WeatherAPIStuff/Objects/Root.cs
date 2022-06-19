using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WeatherAPIStuff.Objects
{
    public class Root
    {
        public Request request { get; set; }
        public Location location { get; set; }
        public Current current { get; set; }
    }
}
