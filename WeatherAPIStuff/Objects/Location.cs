using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WeatherAPIStuff.Objects
{
    public class Location
    {
        public string name { get; set; }
        public string country { get; set; }
        public string region { get; set; }
        public string lat { get; set; }
        public string lon { get; set; }
        public string timezone_id { get; set; }
        public string localtime { get; set; }
        public int localtime_epoch { get; set; }
        public string utc_offset { get; set; }

        public Location(string name, string country, string region, string lat, string lon, string timezone_id, string localtime, int localtime_epoch, string utc_offset)
        {
            this.name = name;
            this.country = country;
            this.region = region;
            this.lat = lat;
            this.lon = lon;
            this.timezone_id = timezone_id;
            this.localtime = localtime;
            this.localtime_epoch = localtime_epoch;
            this.utc_offset = utc_offset;
        }
    }
}
