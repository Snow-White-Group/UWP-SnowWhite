using Domain.HandshakeUseCase;
using Domain.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.SetUpUseCase
{
    public class SetUpCoreInteractor : IHandShakeUseCase
    {
        private readonly IHandshakeUseCase _handshake;

        public SetUpCoreInteractor(IHandshakeUseCase handshake)
        {
            this._handshake = handshake;
        }

        public void SetUpCore()
        {
            this._handshake.handshake();
        }
    }
}
