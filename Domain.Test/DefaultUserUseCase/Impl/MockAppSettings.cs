using Domain.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;

namespace Domain.Test.DefaultUserUseCase.Impl
{
    public class MockAppSettings : MockClass, IAppSettingsService
    {

        public MirrorNames localStorage { get; set; }

        public MirrorNames GetLocalMirrorNames()
        {
            var names = new MirrorNames();
            names.DisplayName = "specFlow#4444";
            names.SecretName = "topSecretName";
            return names;


        }

        public void PutLocalMirrorNames(MirrorNames names)
        {
        }
    }
}
