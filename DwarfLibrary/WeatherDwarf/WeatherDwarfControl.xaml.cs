﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The User Control item template is documented at https://go.microsoft.com/fwlink/?LinkId=234236

namespace DwarfLibrary.WeatherDwarf
{
    public sealed partial class WeatherDwarfControl : UserControl
    {
        #region public fields

        public WeatherDwarfModel Model
        {
            get => (WeatherDwarfModel) GetValue(WeatherProperty);
            set => SetValue(WeatherProperty, value);
        }

        public static readonly DependencyProperty WeatherProperty =
            DependencyProperty.Register("Weather", typeof(WeatherDwarfModel), typeof(WeatherDwarfModel), null);

        #endregion
        public WeatherDwarfControl()
        {
            this.InitializeComponent();
        }
    }

    #region converter
    public class WeatherStateToImageConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            var input = value as WeatherState? ?? WeatherState.Sunny;
            switch (input)
            {
                    case WeatherState.Sunny: return new Uri("ms-appx:///Assets/weather-clear.png");
                    case WeatherState.Cloudly: return new Uri("ms-appx:///Assets/weather-clouds.png");
                    case WeatherState.Raining: return new Uri("ms-appx:///Assets/weather-rainday.png");
                default: return new Uri("ms-appx:///Assets/weather-none-available.png");
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }
    }


    #endregion
}
