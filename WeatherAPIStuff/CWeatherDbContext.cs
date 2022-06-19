using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WeatherAPIStuff.Objects;

namespace WeatherAPIStuff
{
    public class CWeatherDbContext : DbContext
    {
        public DbSet<CWeather> CWeathers { get; set; }
        public CWeatherDbContext(DbContextOptions<CWeatherDbContext> options) : base(options)
        {

        }
    }
}
