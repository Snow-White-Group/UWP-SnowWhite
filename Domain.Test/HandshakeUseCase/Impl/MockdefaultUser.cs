using Domain.DefaultUserUseCase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Test.HandshakeUseCase.Impl
{
    public class MockdefaultUser : MockClass, IDefaultUserUseCase
    {
        public void TriggerDefaultUser()
        {
            hasBeenTriggerd = true;
        }
    }
}
