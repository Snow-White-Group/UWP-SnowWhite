using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.System.Threading;
using Windows.UI.Core;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Imaging;
using Windows.UI.Xaml.Navigation;
using Domain.Entities;
using PropertyChanged;

// The User Control item template is documented at https://go.microsoft.com/fwlink/?LinkId=234236

namespace DwarfLibrary.WeatherDwarf
{
    [ImplementPropertyChanged]
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

        #region private fields
        private int _currentState = 0;
        #endregion

        public WeatherDwarfControl()
        {
           
            this.InitializeComponent();
            EnableAutomaticSwitch();
        }

        #region function
        private void EnableAutomaticSwitch()
        {
            var period = TimeSpan.FromSeconds(15);
            ThreadPoolTimer.CreatePeriodicTimer((source) =>
            {
                Dispatcher?.RunAsync(CoreDispatcherPriority.Low,
                    () =>
                    {
                        VisualStateManager.GoToState(this, this.VisualStateGroup.States.ToArray()[_currentState].Name, true);
                        _currentState = (_currentState + 1) % 2;
                    });
            }, period);
        }
        #endregion
    }

    #region converter
    public class WeatherStateToImageConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            var input = value as WeatherState? ?? WeatherState.Sunny;
            switch (input)
            {
                case WeatherState.Sunny: return new BitmapImage( new Uri("ms-appx:///Assets/weather-clear.png"));
                case WeatherState.Cloudly: return new BitmapImage(new Uri("ms-appx:///Assets/weather-clouds.png"));
                default: return new BitmapImage(new Uri("ms-appx:///Assets/weather-none-available.png"));
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }
    }
    #endregion
}
