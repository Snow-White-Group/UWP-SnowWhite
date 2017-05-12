using System;
using System.Linq;
using PropertyChanged;
using Windows.System.Threading;
using Windows.UI.Core;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace Snowwhite.DwarfLibrary.WeatherDwarf
{
    /// <summary>
    /// The weather dwarf control.
    /// </summary>
    [ImplementPropertyChanged]
    public sealed partial class WeatherDwarfControl : UserControl
    {
        public static readonly DependencyProperty WeatherProperty =
           DependencyProperty.Register("Weather", typeof(WeatherDwarfModel), typeof(WeatherDwarfModel), null);
       
        #region constuctor
        public WeatherDwarfControl()
        {
            this.InitializeComponent();
            this.EnableAutomaticSwitch();
            this.currentState = 0;
        }
        #endregion

        #region public fields
        public WeatherDwarfModel Model
        {
            get
            {
                return (WeatherDwarfModel)this.GetValue(WeatherProperty);
            }

            set
            {
                this.SetValue(WeatherProperty, value);
            }
        }
        #endregion

        #region private fields
        private int currentState;
        #endregion

        #region function
        private void EnableAutomaticSwitch()
        {
            var period = TimeSpan.FromSeconds(15);
            ThreadPoolTimer.CreatePeriodicTimer(
                (source) =>
                    {
                        this.Dispatcher?.RunAsync(
                            CoreDispatcherPriority.Low,
                            () =>
                                {
                                    VisualStateManager.GoToState(this, this.VisualStateGroup.States.ToArray()[this.currentState].Name, true);
                                    this.currentState = (this.currentState + 1) % 2;
                                });
                    },
                period);
        }
        #endregion
    }
}
