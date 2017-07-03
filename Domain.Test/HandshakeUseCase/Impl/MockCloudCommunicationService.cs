using Domain.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;

namespace Domain.Test.HandshakeUseCase.Impl
{
    public class MockCloudCommunicationService : MockClass, IHandshakeService
    {
        public Task<List<MirrorAction>> CheckPostfach(string secretName)
        {
            throw new NotImplementedException();
        }

        public Task<MirrorNames> GetMirrorNames()
        {
            return new TaskFactory().StartNew(() => {
                var names = new MirrorNames();
                names.DisplayName = "specFlow#4444";
                names.SecretName = "topSecretName";
                return names;
            });
        }

        public Task<List<MirrorAction>> GetPostfach(string secretName)
        {
            throw new NotImplementedException();
        }
    }
}
