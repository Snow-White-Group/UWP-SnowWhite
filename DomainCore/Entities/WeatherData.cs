using System;
using System.Collections.Generic;

namespace Domain.Entities
{
    public class WeatherData
    {
        public readonly int CurrentTempeture;
        public readonly WeatherState CurrentState;
        public readonly DateTime CurrentDate;
        public readonly List<Tuple<int, WeatherState>> Forecasts;
        public readonly string LocationName;

        public WeatherData(int currentTempeture, WeatherState currentState, DateTime currentDate, List<Tuple<int, WeatherState>> forecasts, string locationName)
        {
            this.CurrentTempeture = currentTempeture;
            this.CurrentState = currentState;
            this.CurrentDate = currentDate;
            this.Forecasts = forecasts;
            this.LocationName = locationName;
        }
    }
}
