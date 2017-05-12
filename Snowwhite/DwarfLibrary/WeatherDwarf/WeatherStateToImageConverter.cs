using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Media.Imaging;

namespace Snowwhite.DwarfLibrary.WeatherDwarf
{
    public class WeatherStateToImageConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            var input = value as WeatherState? ?? WeatherState.Sunny;
            switch (input)
            {
                case WeatherState.Sunny: return new BitmapImage(new Uri("ms-appx:///Assets/weather-clear.png"));
                case WeatherState.Cloudly: return new BitmapImage(new Uri("ms-appx:///Assets/weather-clouds.png"));
                default: return new BitmapImage(new Uri("ms-appx:///Assets/weather-none-available.png"));
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }
    }
}
