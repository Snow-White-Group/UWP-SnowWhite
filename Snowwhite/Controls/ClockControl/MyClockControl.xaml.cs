using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading;
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
using Windows.UI.Xaml.Navigation;

// The User Control item template is documented at https://go.microsoft.com/fwlink/?LinkId=234236

namespace Snowwhite.Controls.ClockControl
{
    public sealed partial class MyClockControl : UserControl
    {
        public static string Fdate { get; } = " ddd, MM yyyy";
        public static string Ftime { get; } = "hh:mm:ss";

        public MyClockControl()
        {
            this.InitializeComponent();
            
            Time = DateTime.Now.ToString(Ftime);
            Date = DateTime.Now.ToString(Fdate);

            AutoUpdate();
        }

        public string Time
        {
            get => (string) GetValue(TimeProperty);
            set => SetValue(TimeProperty,value);
        }

        public string Date
        {
            get => (string) GetValue(DateProperty);
            set => SetValue(DateProperty, value);
        }

        public static readonly DependencyProperty TimeProperty =
            DependencyProperty.Register("time", typeof(string), typeof(MyClockControl), null);
        public static readonly DependencyProperty DateProperty =
            DependencyProperty.Register("date", typeof(string), typeof(MyClockControl), null);

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
    }
}