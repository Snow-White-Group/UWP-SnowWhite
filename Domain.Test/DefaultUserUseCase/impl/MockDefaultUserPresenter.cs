using Domain.DefaultUserUseCase;

namespace Domain.Test.DefaultUserUseCase.Impl
{
    internal class MockDefaultUserPresenter : IDefaultUserPresenter
    {
        public DefaultUserResponse Response;
        public void OnPresent(DefaultUserResponse response)
        {
            Response = response;
        }
    }
}