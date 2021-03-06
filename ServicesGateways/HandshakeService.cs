﻿using Domain.Entities;
using Domain.Services;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServicesGateways
{
    public class HandshakeService : IHandshakeService
    {
        // instantiate the service for making requests and get responses
        private static readonly CloudService service = new CloudService();

        public async Task<MirrorNames> GetMirrorNames()
        {
            var mirrorNamesResponse = await service.MakeRequest("http://snowwhite-configurationpage.azurewebsites.net/Configuration/GenerateMirrorNames");
            var mirrorNames = JsonConvert.DeserializeObject<MirrorNames>(mirrorNamesResponse);

            return mirrorNames;
        }

        public async Task<List<MirrorAction>> GetPostfach(string secretName)
        {
             var postfachResponse = await service.MakeRequest("http://snowwhite-configurationpage.azurewebsites.net/Configuration/GetPostbox?secretname=" + secretName);
             
             var postfach = JsonConvert.DeserializeObject<List<MirrorAction>>(postfachResponse);

             return postfach;
        }

        public async Task<List<MirrorAction>> CheckPostfach(string secretName)
        {
            var mirrorActions = await GetPostfach(secretName);
            if (mirrorActions != null)
            {
                return mirrorActions;
            }        
            await CheckPostfach(secretName);
            return null;
        }
    }
}
