using Domain.Entities;
using Domain.VoiceUseCases.Services;

namespace Domain.Services
{
    public interface IMirrorStateServices
    {
        VoiceUseCasesState GetCurrentDetectionState();
        void SetCurrentDetectionState(VoiceUseCasesState state);
        void SetCurrentUserTo(MirrorUser user);
        MirrorUser GetCurrentUser();
        MirrorUser LoadDefaultUser();
    }
}