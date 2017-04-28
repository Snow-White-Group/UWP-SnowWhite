using Domain.DefaultUserUseCase;
using Domain.Entities;

namespace Domain.Test.DefaultUserUseCase.impl
{
    internal class MockDefaultUserPresenter : IDefaultUserPresenter
    {
        public DwarfData DwarfData;
        public void OnPresent(DwarfData dwarfData)
        {
            DwarfData = dwarfData;
        }
    }
}