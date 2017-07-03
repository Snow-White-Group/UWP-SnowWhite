using Domain.DefaultUserUseCase;
using Domain.Services;
using Domain.StartupUseCase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.HandshakeUseCase
{
    public class HandshakeInteractor : IHandshakeUseCase
    {
        private readonly IAppSettingsService _appSettingsService;
        private readonly IHandshakeService _handshakeService;
        private readonly IDefaultUserUseCase _defaultUser;


        public HandshakeInteractor(IAppSettingsService appSettingsService, IHandshakeService handshakeService, IDefaultUserUseCase defaultuser)
        {
            this._handshakeService = handshakeService;
            this._appSettingsService = appSettingsService;
            this._defaultUser = defaultuser;
        }

        public async Task handshake()
        {
            var names = await _handshakeService.GetMirrorNames();
            _appSettingsService.PutLocalMirrorNames(names);
            _defaultUser.TriggerDefaultUser();
        }
    }
}
