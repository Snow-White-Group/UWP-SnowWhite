using Domain.Entities;
using Domain.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServicesGateways
{
    public class AppSettingsService : IAppSettingsService
    {
        private static readonly Windows.Storage.ApplicationDataContainer localSettings = Windows.Storage.ApplicationData.Current.LocalSettings;

        public MirrorNames GetLocalMirrorNames()
        {
            MirrorNames names = null;

            if (localSettings.Values["SecretName"] != null && localSettings.Values["DisplayName"] != null)
            {
                names = new MirrorNames()
                {
                    DisplayName = localSettings.Values["DisplayName"].ToString(),
                    SecretName = localSettings.Values["SecretName"].ToString()
                };
                return names;
            }
            else
            {
                return null;
                
            }
        }

        public void PutLocalMirrorNames(MirrorNames names)
        {
          
            localSettings.Values["DisplayName"] = names.DisplayName;
            localSettings.Values["SecretName"] = names.SecretName;
        }
    }
}
