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
            this.ScrollSpeed = 10;
        }
        #endregion
        
        #region public fields
        public static readonly DependencyProperty NewsProperty =
         DependencyProperty.Register("News", typeof(List<NewsDwarfModel>), typeof(NewsDwarfControl), null);

        public static readonly DependencyProperty ShownItemsProperty =
            DependencyProperty.Register("ShownItems", typeof(int), typeof(NewsDwarfControl), null);

        public static readonly DependencyProperty ScrollSpeedProperty =
            DependencyProperty.Register("ScrollSpeed", typeof(int), typeof(NewsDwarfControl), null);

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

        public ThreadPoolTimer Thread { get; set; }

        public int ScrollSpeed
        {
            get
            {
                return (int)this.GetValue(ScrollSpeedProperty);
            }

            set
            {
                Thread.Cancel();
                this.SetValue(ScrollSpeedProperty, value);
                AutoScroll();
            }


        }
        #endregion

        #region private fields
        private int currentIndex;
        #endregion

        #region function
        private void AutoScroll()
        {
            var period = TimeSpan.FromSeconds(ScrollSpeed);
            Thread = ThreadPoolTimer.CreatePeriodicTimer(
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
