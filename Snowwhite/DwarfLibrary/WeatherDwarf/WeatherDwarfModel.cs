using System;
using System.Collections.Generic;
using Domain.Entities;
using PropertyChanged;

namespace Snowwhite.DwarfLibrary.WeatherDwarf
{
    [ImplementPropertyChanged]
    public class WeatherDwarfModel
    {
        public readonly double CurrentTempeture;
        public readonly WeatherState CurrentState;
        public readonly DateTime CurrentDate;
        public readonly List<ForecastModel> Forecasts;
        public readonly string LocationName;

        public readonly WeatherUnit Unit;

        public WeatherDwarfModel(
         double currentTempeture,
         WeatherState currentState,
         DateTime currentDate,
         List<ForecastModel> forecasts,
         string locationName,
         WeatherUnit unit)
        {
            this.CurrentTempeture = currentTempeture;
            this.CurrentState = currentState;
            this.CurrentDate = currentDate;
            this.Forecasts = forecasts;
            this.LocationName = locationName;
            this.Unit = unit;
        }



        public string DisplayText => ConvertToUnit(CurrentTempeture);

        private string ConvertToUnit(double k)
        {
            switch (Unit)
            {
                case WeatherUnit.Kelvin: return k.ToString("00") + "K";
                case WeatherUnit.Fahrenheit: return (1.8 * k - 459.67).ToString("00") + "°F";
                default: return (k - 273).ToString("00") + "°C";
            }

        }
    }
}