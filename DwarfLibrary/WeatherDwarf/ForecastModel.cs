using System;

namespace DwarfLibrary.WeatherDwarf
{
    public class ForecastModel
    {
        public readonly DateTime Date;
        public readonly int Tempeture;
        public readonly WeatherState State;

        public ForecastModel(DateTime date, int tempeture, WeatherState state)
        {
            Date = date;
            Tempeture = tempeture;
            State = state;
        }

        public string DisplayText
        {
            get => "Mo, 21°C";
        }
    }
}