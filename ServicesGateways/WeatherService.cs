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
using ServicesGateways;

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

        public async Task<WeatherData> GetWeather(string city)
        {
            //delete all existing rows
            //db.Weather.RemoveRange(db.Weather);

            var forecasts = new List<WeatherData>();

            //request for weather
            var weatherResponse = await service.MakeRequest("http://api.openweathermap.org/data/2.5/forecast?q=" + city + "&appid=" + API_KEY);

            var weather = JsonConvert.DeserializeObject<WeatherForecast>(weatherResponse);
            weather.LastUpdate = (int)(DateTime.UtcNow.Subtract(new DateTime(1970, 1, 1)).TotalSeconds);
            
           

            foreach (List w in weather.List)
            {
                //max temparature
                var currentTemperature = w.Main.Temp_max;
                var currentState = w.Clouds.All < 3 ? WeatherState.Sunny :
                               w.Rain.ThreeHours > 30.0 ? WeatherState.Raining :  WeatherState.Cloudly ;
                // do not know wheather this works..
                var currentDate = new DateTime(w.DT);
               

                forecasts.Add(new WeatherData(currentTemperature, currentState, currentDate, weather.City.Name));

                //save in db
                //db.Weather.Add(weather);
            }
            if (forecasts.Count < 1) return null;
            var today = forecasts.First();
 
            if (!forecasts.Remove(today)) return null;
            today.Forecast = forecasts;

            //db.SaveChanges();

            //returns the forecasts
            return today;
        }
    }
}
