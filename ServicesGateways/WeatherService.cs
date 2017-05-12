using Domain.Entities;
using Domain.Services;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using Windows.Data.Json;

namespace ServicesGateways
{
    public class WeatherService : IWeatherService
    {
        // api key
        private static readonly string API_KEY = "c55bfb1d2457c2568fa1dfb92dd07606";

        // instantiate the service for making requests and get responses
        private static readonly WebService service = new WebService();

        // db context for the local db
        //private static readonly ServicesDbContext db = new ServicesDbContext();

        public async Task<WeatherData> GetWeather(string city)
        {
            // delete all existing rows
            //db.Weather.RemoveRange(db.Weather);

            // request for weather

            /**
            string weatherResponse = await service.MakeRequest("http://api.openweathermap.org/data/2.5/forecast?q=" + city + "&appid=" + API_KEY);

            WeatherForecast weather = JsonConvert.DeserializeObject<WeatherForecast>(weatherResponse);
            weather.LastUpdate = (Int32)(DateTime.UtcNow.Subtract(new DateTime(1970, 1, 1)).TotalSeconds);

            var first = weather;
            var list = weather.list;
            var main = list.main;
            var CurrentTempeture = main.temp_max;
            var CurrentState = WeatherState.Sunny;
            var CurrentDate = new DateTime();

            foreach (WeatherForecast w in weather.list)
            var CurrentTempeture = weather.list.main;
            var CurrentState;
            var CurrentDate;
            var Forecasts;
            var LocationName;
 
        WeatherData weatherData = new WeatherData(weather.list.);
       **/
            //db.Weather.Add(weather);
            //db.SaveChanges();

            return null;
        }
    }
}
