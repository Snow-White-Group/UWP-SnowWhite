using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Core;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Domain.Boundaries;
using Snowwhite.UseCases.DefaultUserUseCase;

namespace Snowwhite.Services
{
    class NavigateService : IDeliveryBoundary
    {
        private readonly Dictionary<string, Type> pagesByKey = new Dictionary<string, Type>();

        async Task<bool> IDeliveryBoundary.DeliverEnrollmentPage()
        {
            throw new NotImplementedException();

        }

        public async Task<bool> DeliverDefaultUserPage()
        {
            var r = Window.Current.Dispatcher?.RunAsync(CoreDispatcherPriority.Normal,
                () =>
                {
                    NavigateTo(typeof(DefaultUserPage).FullName);
                }).AsTask();

            return r != null && r.Exception == null;
        }

        public void RegistratePage<T>(Type pageType)
        {
            lock (this.pagesByKey)
            {
                var key = typeof(T).FullName;

                //check page
                if (this.pagesByKey.ContainsKey(key))
                    throw new ArgumentException("This page has been registrated before: " + key);
                else if (this.pagesByKey.Any(p => p.Value == pageType))
                    throw new ArgumentException("This page has been registrated before: " + key);
                
                //add page
                this.pagesByKey.Add(key, pageType);
            }
        }

        private bool NavigateTo(string pageKey, object parameter = null)
        {
            lock (pageKey)
            {
                var frame = (Frame) Window.Current.Content;
                return frame.Navigate(this.pagesByKey[pageKey], parameter);
            }
        }
    }
}
