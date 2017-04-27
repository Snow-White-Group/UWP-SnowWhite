using Domain.Entities;
using Domain.Services;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServicesGateways
{
    public class WeatherService : IWeatherService
    {
        // api key
        private static readonly string API_KEY = "c55bfb1d2457c2568fa1dfb92dd07606";

        // instantiate the service for making requests and get responses
        private static readonly WebService service = new WebService();

        // db context for the local db
        private static readonly ServicesDbContext db = new ServicesDbContext();

        public async Task<Weather> GetWeather(string city)
        {
            // delete all existing rows
            //db.Weather.RemoveRange(db.Weather);

            // request for weather
            string weatherResponse = await service.MakeRequest("api.openweathermap.org/data/2.5/weather?q=" + city + "&appid=" + API_KEY);

            // parse json to weather object
            Weather weather =  JObject.Parse(weatherResponse).ToObject<Weather>();
            weather.LastUpdate = Convert.ToInt64(DateTime.Now.ToString("yyyymmddhhmmssffff"));

            db.Weather.Add(weather);
            db.SaveChanges();

            return weather;
        }
    }
}
