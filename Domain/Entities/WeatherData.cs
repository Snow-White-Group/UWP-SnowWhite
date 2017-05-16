using System;
using System.Collections.Generic;

namespace Domain.Entities
{
    public class WeatherData
    {
        public double CurrentTempeture;
        public WeatherState CurrentState;
        public DateTime CurrentDate;
        public List<WeatherData> Forecast;
        public string LocationName;

        public WeatherData(double currentTempeture, WeatherState currentState, DateTime currentDate, string locationName, List<WeatherData> forcast)
        {
            this.CurrentTempeture = currentTempeture;
            this.CurrentState = currentState;
            this.CurrentDate = currentDate;
            this.LocationName = locationName;
            this.Forecast = forcast;
        }

        public WeatherData(double currentTempeture, WeatherState currentState, DateTime currentDate, string locationName)
        {
            this.CurrentTempeture = currentTempeture;
            this.CurrentState = currentState;
            this.CurrentDate = currentDate;
            this.LocationName = locationName;
        }
    }
}
