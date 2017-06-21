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

        public async Task<MirrorNames> GetLocalMirrorNames()
        {
            MirrorNames names = null;

            if (localSettings.Values["SecretName"] != null && localSettings.Values["DisplayName"] != null)
            {
                names = new MirrorNames()
                {
                    DisplayName = localSettings.Values["DisplayName"].ToString(),
                    SecretName = localSettings.Values["SecretName"].ToString()
                };
            }
            else
            {
                HandshakeService _handshakeServ = new HandshakeService();
                names = await _handshakeServ.GetMirrorNames();

                localSettings.Values["DisplayName"] = names.DisplayName;
                localSettings.Values["SecretName"] = names.SecretName;
            }

            return names;
        }
    }
}
