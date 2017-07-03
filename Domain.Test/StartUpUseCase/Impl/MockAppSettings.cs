using Domain.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;

namespace Domain.Test.StartUpUseCase.Impl
{
    public class MockAppSettings : MockClass, IAppSettingsService
    {
        public bool hasMirrorName { get; set; }
        public readonly MirrorNames names;

        public MockAppSettings()
        {
            this.names = new MirrorNames();
            names.DisplayName = "specFlow#4444";
            names.SecretName = "topSecretName";
        }

        public MirrorNames GetLocalMirrorNames()
        {
            if(hasMirrorName)
            {
                return names;
            } else
            {
                return null;
            }
        }

        public void PutLocalMirrorNames(MirrorNames names)
        {
            throw new NotImplementedException();
        }
    }
}
