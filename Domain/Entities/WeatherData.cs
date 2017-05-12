using System;
using System.Collections.Generic;

namespace Domain.Entities
{
    public class WeatherData
    {
        public double CurrentTempeture;
        public WeatherState CurrentState;
        public DateTime CurrentDate;
        public WeatherData Forecast;
        public string LocationName;

        public WeatherData(double currentTempeture, WeatherState currentState, DateTime currentDate, string locationName)
        {
            this.CurrentTempeture = currentTempeture;
            this.CurrentState = currentState;
            this.CurrentDate = currentDate;
            //this.Forecast = forecast; was willst du hier Cem?!
            this.LocationName = locationName;
        }

        public void AddForecast(WeatherData weather)
        {
            if(this.Forecast == null)
            {
                this.Forecast = weather;
            } else
            {
                this.Forecast.AddForecast(weather);
            }
        }
    }
}
