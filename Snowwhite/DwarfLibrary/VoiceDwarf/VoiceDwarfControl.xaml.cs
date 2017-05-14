using System;
using System.Collections.Generic;
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
using Windows.UI.Xaml.Navigation;

// The User Control item template is documented at https://go.microsoft.com/fwlink/?LinkId=234236

namespace Snowwhite.DwarfLibrary.VoiceDwarf
{
    public sealed partial class VoiceDwarfControl : UserControl
    {
        private int count = 0;

        public VoiceDwarfControl()
        {
            this.InitializeComponent();
            AnimationTest();
            EventHide.Begin();
        }


        #region function
        private void AnimationTest()
        {
            var period = TimeSpan.FromSeconds(2);
            ThreadPoolTimer.CreatePeriodicTimer(
                (source) =>
                {
                    this.Dispatcher?.RunAsync(
                        CoreDispatcherPriority.Low,
                        () =>
                        {
                            this.count = (this.count + 1) % 2;
                            if (count == 0) EventShow.Begin();
                            else EventHide.Begin();


                        });
                },
                period);
        }
        #endregion
    }
}
