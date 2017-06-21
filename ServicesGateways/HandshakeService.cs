using Domain.Entities;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServicesGateways
{
    public class HandshakeService
    {
        // instantiate the service for making requests and get responses
        private static readonly WebService service = new WebService();

        public async Task<MirrorNames> GetMirrorNames()
        {
            var mirrorNamesResponse = await service.MakeRequest("http://snowwhite-configurationpage.azurewebsites.net/Configuration/GenerateMirrorNames");
            var mirrorNames = JsonConvert.DeserializeObject<MirrorNames>(mirrorNamesResponse);

            return mirrorNames;
        }

        public async Task GetPostfach(string mirrorId)
        {
            var postfachResponse = await service.MakeRequest("http://snowwhite-configurationpage.azurewebsites.net/Configuration/GetPostbox?id=" + mirrorId);
            // user model is different and no mirror model
            // var postfach = JsonConvert.DeserializeObject<Actions>(postfachResponse);

            // return List<Action>;
        }

        public async Task MakeHandshake(string secretName)
        {
            var postfachResponse = await service.MakeRequest("http://snowwhite-configurationpage.azurewebsites.net/Configuration/Handshake?secretname=" + secretName);
            // what here?
        }
    }
}
