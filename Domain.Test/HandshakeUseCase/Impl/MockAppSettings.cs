using Domain.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;

namespace Domain.Test.HandshakeUseCase.Impl
{
    public class MockAppSettings : MockClass, IAppSettingsService
    {

        public MirrorNames localStorage { get; set; }

        public MirrorNames GetLocalMirrorNames()
        {
            return localStorage;
        }

        public void PutLocalMirrorNames(MirrorNames names)
        {
            localStorage = names;
        }
    }
}
