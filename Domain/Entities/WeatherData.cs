using System;
using System.Collections.Generic;

namespace Domain.Entities
{
    public class WeatherData
    {
        public int CurrentTempeture;
        public WeatherState CurrentState;
        public DateTime CurrentDate;
        public WeatherData Forecast;
        public string LocationName;

        public WeatherData(int currentTempeture, WeatherState currentState, DateTime currentDate, WeatherData forecast, string locationName)
        {
            this.CurrentTempeture = currentTempeture;
            this.CurrentState = currentState;
            this.CurrentDate = currentDate;
            this.Forecast = forecast;
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
