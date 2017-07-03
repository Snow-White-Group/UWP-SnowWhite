using Domain.SetUpUseCase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Test.StartUpUseCase.Impl
{
    public class MockSetUP : MockClass, IHandShakeUseCase
    {
        public void SetUpCore()
        {
            hasBeenTriggerd = true;
        }
    }
}
