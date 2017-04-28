using Domain.Entities;
using Domain.Services;

namespace Domain.Test.DefaultUserUseCase.impl
{
    internal class MockConfigurationPageService : IConfigurationPageService
    {
        public MirrorUser LoadDefaultUser()
        {
            var snowUser = new SnowUser("Dominik", "Jülg", "hello@fresh.de", "JOJOJO_ID");
            return new MirrorUser(snowUser, true, true, "annoonnnyyymmmm");
        }
    }
}