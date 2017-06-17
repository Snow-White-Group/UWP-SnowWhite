using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
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
using PropertyChanged;
using Snowwhite.DwarfLibrary.NewsDwarf;

// The User Control item template is documented at https://go.microsoft.com/fwlink/?LinkId=234236

namespace Snowwhite.DwarfLibrary.VoiceDwarf
{
    [ImplementPropertyChanged]
    public sealed partial class VoiceDwarfControl : UserControl
    {
        public VoiceDwarfControl()
        {
            this.InitializeComponent();
        }

        #region public

        public String EventText
        {
            get { return (String)this.GetValue(EventTextProperty); }
            set
            {
                this.SetValue(EventTextProperty, value);
                EventTextAnimation();
            }
        }

        public String InnerText
        {
            get { return (String)this.GetValue(InnerTextProperty); }
            set
            {
                this.SetValue(InnerTextProperty, value);
            }
        }

        public VoiceDwarfState DwarfState
        {
            set => VisualStateManager.GoToState(this, MapToState(value) , true);
        }


        public static readonly DependencyProperty EventTextProperty =
            DependencyProperty.Register("MyEventText", typeof(String), typeof(VoiceDwarfControl), null);

        public static readonly DependencyProperty InnerTextProperty =
            DependencyProperty.Register("MyInnerText", typeof(String), typeof(VoiceDwarfControl), null);


        #endregion


        private static String MapToState(VoiceDwarfState value)
        {
            switch (value)
            {
                case VoiceDwarfState.Listining: return "Nothing";
                case VoiceDwarfState.Recording: return "Recording";
                default: return "Disabled";
            }
        }

  

        private void EventTextAnimation()
        {
            Window.Current.Dispatcher?.RunAsync(CoreDispatcherPriority.Normal, () => { EventHide.Begin(); });
            EventHideAnimation();
        }


        private void EventHideAnimation()
        {
            new TaskFactory().StartNew(async () =>
            {
                await Task.Delay(TimeSpan.FromSeconds(10));
                Window.Current.Dispatcher?.RunAsync(CoreDispatcherPriority.Normal, () => { EventHide.Begin(); });
            });
        }

    }

    public enum VoiceDwarfState
    {
        Training, Listining, Recording
    }
}
