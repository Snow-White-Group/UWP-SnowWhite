using Domain.Entities;
using Domain.Services;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
        //private static readonly ServicesDbContext db = new ServicesDbContext();

        public async Task<WeatherData> GetWeather(string city)
        {
            //delete all existing rows
            //db.Weather.RemoveRange(db.Weather);

            var forecasts = new List<WeatherData>();

            //request for weather
            var weatherResponse = await service.MakeRequest("http://api.openweathermap.org/data/2.5/forecast?q=" + city + "&appid=" + API_KEY);
            // replaced the 3h variable name and replaced with ThreeHours
            weatherResponse = Regex.Replace(weatherResponse, "3h", "ThreeHours");
            var weather = JsonConvert.DeserializeObject<WeatherForecast>(weatherResponse);
            weather.LastUpdate = (int)(DateTime.UtcNow.Subtract(new DateTime(1970, 1, 1)).TotalSeconds);
           
            foreach (List w in weather.List)
            {
                //max temparature
                var currentTemperature = w.Main.Temp_max;
                //  WeatherState.Raining missing because of mapping problem with 3h
                var currentState = w.Clouds.All <= 20 ? WeatherState.Sunny :
                    w.Rain != null && w.Rain.ThreeHours > 30.0 ? WeatherState.Raining : WeatherState.Cloudly;
                
                var currentDate = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc).AddSeconds(w.DT);
                
                forecasts.Add(new WeatherData(currentTemperature, currentState, currentDate, weather.City.Name));

                //save in db
                //db.Weather.Add(weather);
            }

            var maxTemparatures = forecasts.GroupBy(item => item.CurrentDate.Day)
                .Select(grp => grp.OrderByDescending(temp => temp.CurrentTempeture).FirstOrDefault());

            if (forecasts.Count < 1)
            {
                return null;
            }

            var today = forecasts.First();

            if (!forecasts.Remove(today))
            {
                return null;
            }

            today.Forecast = maxTemparatures.ToList();

            //db.SaveChanges();

            //returns the forecasts
            return today;
        }
    }
}
