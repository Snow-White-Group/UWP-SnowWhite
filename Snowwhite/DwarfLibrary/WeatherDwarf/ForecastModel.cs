using System;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Media.DialProtocol;
using Domain.Entities;
using PropertyChanged;

namespace Snowwhite.DwarfLibrary.WeatherDwarf
{
    [ImplementPropertyChanged]
    public class ForecastModel
    {
        public readonly DateTime Date;
        public readonly double Tempeture;
        public readonly WeatherState WeatherState;

        public readonly WeatherUnit Unit;

        public ForecastModel(DateTime date, double tempeture, WeatherState state, WeatherUnit unit)
        {
            this.Date = date;
            this.Tempeture = tempeture;
            this.WeatherState = state;
            this.Unit = unit;
        }

        public string DisplayText => Date.ToString("dddd, ") + ConvertToUnit(Tempeture) ;

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