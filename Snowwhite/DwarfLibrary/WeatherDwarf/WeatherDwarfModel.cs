using System;
using System.Collections.Generic;
using PropertyChanged;

namespace DwarfLibrary.WeatherDwarf
{
    [ImplementPropertyChanged]
    public class WeatherDwarfModel
    {
        public readonly int CurrentTempeture;
        public readonly WeatherState CurrentState;
        public readonly DateTime CurrentDate;
        public readonly List<ForecastModel> Forecasts;
        public readonly string LocationName;

        public string DisplayText => CurrentTempeture + "°C";

        public WeatherDwarfModel(int currentTempeture, WeatherState currentState, DateTime currentDate, List<ForecastModel> forecasts, string locationName)
        {
            CurrentTempeture = currentTempeture;
            CurrentState = currentState;
            CurrentDate = currentDate;
            Forecasts = forecasts;
            LocationName = locationName;
        }
    }
}