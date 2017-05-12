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
        //private static readonly ServicesDbContext db = new ServicesDbContext();

        public async Task<List<WeatherData>> GetWeather(string city)
        {
            // delete all existing rows
            //db.Weather.RemoveRange(db.Weather);

            List<WeatherData> forecasts = new List<WeatherData>();

            // request for weather

            /**
            string weatherResponse = await service.MakeRequest("http://api.openweathermap.org/data/2.5/forecast?q=" + city + "&appid=" + API_KEY);

            WeatherForecast weather = JsonConvert.DeserializeObject<WeatherForecast>(weatherResponse);
            weather.LastUpdate = (Int32)(DateTime.UtcNow.Subtract(new DateTime(1970, 1, 1)).TotalSeconds);
            
            double CurrentTemperature;
            WeatherState CurrentState;
            DateTime CurrentDate;

            foreach (List w in weather.List)
            {
                // max temparature
                CurrentTemperature = w.Main.Temp_max;
                CurrentState = w.Clouds.All < 3 ? WeatherState.Sunny :
                               w.Rain.ThreeHours > 30.0 ? WeatherState.Raining :  WeatherState.Cloudly ;
                CurrentDate = new DateTime(w.DT);

                forecasts.Add(new WeatherData(CurrentTemperature, CurrentState, CurrentDate, weather.City.Name));

                // save in db
                //db.Weather.Add(weather);
            }
            //db.SaveChanges();

            // returns the forecasts
            return forecasts;
        }
    }
}
