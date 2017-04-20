using System;
using System.Collections.Generic;
using System.Diagnostics;
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
using Windows.System.Threading;
using Windows.UI.Core;
using ExtensionMethods;


// The User Control item template is documented at https://go.microsoft.com/fwlink/?LinkId=234236

namespace DwarfLibrary.NewsDwarf
{
    public sealed partial class NewsDwarfControl : UserControl
    {
        #region public fields
        public List<NewsDwarfModel> News
        {
            get => (List<NewsDwarfModel>) GetValue(NewsProperty);
            set => SetValue(NewsProperty, value);
        }

        public int ShownItems
        {
            get => (int) GetValue(ShownItemsProperty);
            set => SetValue(ShownItemsProperty,value);
        }

        public static readonly DependencyProperty NewsProperty =
            DependencyProperty.Register("News", typeof(List<NewsDwarfModel>), typeof(NewsDwarfControl), null);
        public static readonly DependencyProperty ShownItemsProperty =
            DependencyProperty.Register("ShownItems", typeof(List<NewsDwarfModel>), typeof(NewsDwarfControl), null);
        #endregion

        #region private fields
        private int currentIndex = 0;
        #endregion
        public NewsDwarfControl()
        {
            this.InitializeComponent();
            AutoScroll();
        }

        #region function
        private void AutoScroll()
        {
            var period = TimeSpan.FromSeconds(10);
            ThreadPoolTimer.CreatePeriodicTimer((source) =>
            {
                Dispatcher?.RunAsync(CoreDispatcherPriority.High,
                () =>
                {
                    currentIndex = (currentIndex + 1) % News.Count;
                    NewsList?.ScrollToIndex(currentIndex).ConfigureAwait(false);
                });
            }, period);
        }
        #endregion
    }

    public class ShownItemsConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            var input = value as int? ?? 1;
            return System.Convert.ToDouble(input * 152);
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }
    }
}
