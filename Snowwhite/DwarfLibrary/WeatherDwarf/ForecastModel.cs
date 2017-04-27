using System;

namespace DwarfLibrary.WeatherDwarf
{
    public class ForecastModel
    {
        public readonly DateTime Date;
        public readonly int Tempeture;
        public readonly WeatherState WeatherState;

        public string DisplayText => Date.ToString("ddd, ") + Tempeture + "°C";

        public ForecastModel(DateTime date, int tempeture, WeatherState state)
        {
            Date = date;
            Tempeture = tempeture;
            WeatherState = state;
        }

    }
}