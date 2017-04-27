using System;
using Windows.System.Threading;
using Windows.UI.Core;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

// The User Control item template is documented at https://go.microsoft.com/fwlink/?LinkId=234236

namespace DwarfLibrary.ClockDwarf
{
    public sealed partial class ClockDwarfControl : UserControl
    {
        #region public fields
        public static string Fdate { get; } = " ddd, MM. yyyy";
        public static string Ftime { get; } = "hh:mm:ss";
        public string Time
        {
            get => (string)GetValue(TimeProperty);
            set => SetValue(TimeProperty, value);
        }
        public string Date
        {
            get => (string)GetValue(DateProperty);
            set => SetValue(DateProperty, value);
        }
        public static readonly DependencyProperty TimeProperty =
            DependencyProperty.Register("time", typeof(string), typeof(ClockDwarfControl), null);
        public static readonly DependencyProperty DateProperty =
            DependencyProperty.Register("date", typeof(string), typeof(ClockDwarfControl), null);
        #endregion

        #region constuctor
        public ClockDwarfControl()
        {
            this.InitializeComponent();

            Time = DateTime.Now.ToString(Ftime);
            Date = DateTime.Now.ToString(Fdate);

            AutoUpdate();
        }
        #endregion

        #region function
        private void AutoUpdate()
        {
            var period = TimeSpan.FromSeconds(1);
            ThreadPoolTimer.CreatePeriodicTimer((source) =>
            {
                Dispatcher?.RunAsync(CoreDispatcherPriority.High,
                    () =>
                    {
                        Time = DateTime.Now.ToString(Ftime);
                        Date = DateTime.Now.ToString(Fdate);
                    });
            }, period);
        }
        #endregion
    }
}