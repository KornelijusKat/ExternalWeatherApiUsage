using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using WeatherAPIStuff.Objects;

namespace WeatherAPIStuff.Weather_Services
{
    public class WeatherServices
    {
        private readonly HttpClient _http;
        public WeatherServices(HttpClient http)
        {
            _http = http;
        }
        public async Task<string> HttpClientExtension(string city)
        {
            try
            {
                var testing = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build().GetSection("AccessKey");
                var request = new HttpRequestMessage
                {
                    Method = HttpMethod.Get,
                    RequestUri = new Uri("http://api.weatherstack.com/current?access_key=" + testing.Value + "&query=" + city)
                };
                using var response = await _http.SendAsync(request);
                response.EnsureSuccessStatusCode();
                var body = await response.Content.ReadAsStringAsync();
                return body;
            }
            catch(Exception e)
            {
                throw new Exception(e.Message);
                          
            }
        }
    }
}
