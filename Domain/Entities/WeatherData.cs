using System;
using System.Collections.Generic;

namespace Domain.Entities
{
    public class WeatherData
    {
        public readonly int CurrentTempeture;
        public readonly String CurrentState;
        public readonly DateTime CurrentDate;
        public readonly List<String> Forecasts;
        public readonly string LocationName;

        public WeatherData(int currentTempeture, string currentState, DateTime currentDate, List<string> forecasts, string locationName)
        {
            CurrentTempeture = currentTempeture;
            CurrentState = currentState;
            CurrentDate = currentDate;
            Forecasts = forecasts;
            LocationName = locationName;
        }
    }
}
