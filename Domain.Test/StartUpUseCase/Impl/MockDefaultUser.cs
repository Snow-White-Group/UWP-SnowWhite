using Domain.DefaultUserUseCase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Test.StartUpUseCase.Impl
{
    public class MockDefaultUser : MockClass, IDefaultUserUseCase
    
    {
        public void TriggerDefaultUser()
        {
            hasBeenTriggerd = true;
        }
    }
}
