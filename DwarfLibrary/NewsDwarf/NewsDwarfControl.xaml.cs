using System;
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

namespace DwarfLibrary.NewsDwarf
{
    public sealed partial class NewsDwarfControl : UserControl
    {
        #region public fields
        public List<NewsModel> News
        {
            get => (List<NewsModel>)GetValue(NewsProperty);
            set => SetValue(NewsProperty, value);
        }
        public static readonly DependencyProperty NewsProperty =
            DependencyProperty.Register("news", typeof(List<NewsModel>), typeof(NewsDwarfControl), null);
        #endregion

        public NewsDwarfControl()
        {
            this.InitializeComponent();
        }
    }
}
