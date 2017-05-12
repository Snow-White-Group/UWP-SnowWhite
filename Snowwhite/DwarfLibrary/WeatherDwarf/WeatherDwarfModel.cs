using System;
using System.Collections.Generic;
using Domain.Entities;
using global::DwarfLibrary.WeatherDwarf;
using PropertyChanged;

namespace Snowwhite.DwarfLibrary.WeatherDwarf
{
    [ImplementPropertyChanged]
    public class WeatherDwarfModel
    {
        public WeatherDwarfModel(
         int currentTempeture,
         WeatherState currentState,
         DateTime currentDate,
         List<ForecastModel> forecasts,
         string locationName)
        {
            this.CurrentTempeture = currentTempeture;
            this.CurrentState = currentState;
            this.CurrentDate = currentDate;
            this.Forecasts = forecasts;
            this.LocationName = locationName;
        }

        public readonly int CurrentTempeture;
        public readonly WeatherState CurrentState;
        public readonly DateTime CurrentDate;
        public readonly List<ForecastModel> Forecasts;
        public readonly string LocationName;

        public string DisplayText => this.CurrentTempeture + "°C";
    }
}