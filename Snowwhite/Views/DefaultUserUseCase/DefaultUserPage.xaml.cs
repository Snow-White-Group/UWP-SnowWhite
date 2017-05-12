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
using Snowwhite.ViewModels.DefaultUserUseCase;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace Snowwhite.UseCases.DefaultUserUseCase
{
    using System.Diagnostics;

    using Windows.System.Threading;
    using Windows.UI.Core;

    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class DefaultUserPage : Page
    {

        public DefaultUserPage()
        {
            this.InitializeComponent();
        }

        public DefaultUserViewModel ViewModel => (DefaultUserViewModel)this.DataContext;

    }
}
