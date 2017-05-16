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
            this.LocationName = locationName;
        }
    }
}
