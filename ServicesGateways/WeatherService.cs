using Domain.Entities;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServicesGateways
{
    public class WeatherService
    {
        // api key
        private static readonly string API_KEY = "c55bfb1d2457c2568fa1dfb92dd07606";

        // instantiate the service for making requests and get responses
        private static readonly WebService service = new WebService();

        public async Task<Weather> GetWeather(string city)
        {
            // request for weather
            string weatherResponse = await service.MakeRequest("api.openweathermap.org/data/2.5/weather?q=" + city + "&appid=" + API_KEY);

            // parse json to weather object
            Weather weather =  JObject.Parse(weatherResponse).ToObject<Weather>();

            return weather;
        }
    }
}
