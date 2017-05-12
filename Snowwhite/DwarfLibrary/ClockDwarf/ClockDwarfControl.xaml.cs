using System;
using Windows.System.Threading;
using Windows.UI.Core;
using Windows.UI.Xaml.Controls;

// The User Control item template is documented at https://go.microsoft.com/fwlink/?LinkId=234236

namespace Snowwhite.DwarfLibrary.ClockDwarf
{
    /// <summary>
    /// The clock dwarf control.
    /// </summary>
    public sealed partial class ClockDwarfControl : UserControl
    {
        public static readonly Windows.UI.Xaml.DependencyProperty TimeProperty =
           Windows.UI.Xaml.DependencyProperty.Register("time", typeof(string), typeof(ClockDwarfControl), null);

        public static readonly Windows.UI.Xaml.DependencyProperty DateProperty =
            Windows.UI.Xaml.DependencyProperty.Register("date", typeof(string), typeof(ClockDwarfControl), null);
       
        #region constuctor
        public ClockDwarfControl()
        {
            this.InitializeComponent();

            this.Time = DateTime.Now.ToString(Ftime);
            this.Date = DateTime.Now.ToString(Fdate);
            this.AutoUpdate();
        }
        #endregion

        #region public fields
        public static string Fdate { get; } = " ddd, MM. yyyy";

        public static string Ftime { get; } = "hh:mm:ss";

        public string Time
        {
            get { return (string)this.GetValue(TimeProperty); }
            set { this.SetValue(TimeProperty, value); }
        }
        public string Date
        {
            get { return (string)this.GetValue(DateProperty); }
            set { this.SetValue(DateProperty, value); }
        }
        #endregion

        #region function
        private void AutoUpdate()
        {
            var period = TimeSpan.FromSeconds(1);
            ThreadPoolTimer.CreatePeriodicTimer(
                (source) =>
                    {
                        this.Dispatcher?.RunAsync(
                            CoreDispatcherPriority.High,
                            () =>
                                {
                                    this.Time = DateTime.Now.ToString(Ftime);
                                    this.Date = DateTime.Now.ToString(Fdate);
                                });
                    },
                period);
        }
        #endregion
    }
}