using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using PropertyChanged;

using Windows.System.Threading;
using Windows.UI.Core;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Snowwhite.Utility;

// The User Control item template is documented at https://go.microsoft.com/fwlink/?LinkId=234236
namespace Snowwhite.DwarfLibrary.NewsDwarf
{
    /// <summary>
    /// The news dwarf control.
    /// </summary>
    [ImplementPropertyChanged]
    public sealed partial class NewsDwarfControl : UserControl
    {
        [SuppressMessage("StyleCop.CSharp.ReadabilityRules", "SA1126:PrefixCallsCorrectly", Justification = "Reviewed. Suppression is OK here.")]
        [SuppressMessage("StyleCop.CSharp.OrderingRules", "SA1201:ElementsMustAppearInTheCorrectOrder", Justification = "Reviewed. Suppression is OK here.")]

        #region constuctor
        public NewsDwarfControl()
        {
            this.InitializeComponent();
            this.AutoScroll();
            this.currentIndex = 0;
        }
        #endregion
        
        #region public fields
        public static readonly DependencyProperty NewsProperty =
         DependencyProperty.Register("News", typeof(List<NewsDwarfModel>), typeof(NewsDwarfControl), null);

        public static readonly DependencyProperty ShownItemsProperty =
            DependencyProperty.Register("ShownItems", typeof(int), typeof(NewsDwarfControl), null);

        public List<NewsDwarfModel> News
        {
            get { return (List<NewsDwarfModel>) this.GetValue(NewsProperty); }
            set
            {
                this.SetValue(NewsProperty , value );
            }
        }

        public int ShownItems
        {
            get
            {
                return (int)this.GetValue(ShownItemsProperty);
            }

            set
            {
                this.SetValue(ShownItemsProperty, value);
            }


        }
        #endregion

        #region private fields
        private int currentIndex;
        #endregion

        #region function
        private void AutoScroll()
        {
            var period = TimeSpan.FromSeconds(5);
            ThreadPoolTimer.CreatePeriodicTimer(
                (source) =>
                    {
                        this.Dispatcher?.RunAsync(
                            CoreDispatcherPriority.Low,
                            () =>
                                {

                                    if (this.News == null)
                                    {
                                        return;
                                    }

                                    this.currentIndex = (this.currentIndex + 1) % this.News.Count;
                                    NewsList?.ScrollToIndex(this.currentIndex).ConfigureAwait(false);
                                });
                    },
                period);
        }
        #endregion
    }
}
