using Domain.Entities;

namespace Domain.Services
{
    public interface IMirrorStateServices
    {
        void SetCurrentUserTO(MirrorUser user);
        MirrorUser GetCurrentUser();
    }
}