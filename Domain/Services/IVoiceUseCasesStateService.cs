using Domain.Entities;
using Domain.Services;

namespace Domain.VoiceUseCases.Services
{
    public interface IVoiceUseCasesStateService
    {
        VoiceUseCasesState GetCurrentDetectionState();

        void SetCurrentDetectionState(VoiceUseCasesState state);

        SnowUser GetUserForEnrollment();

        void SetUserForEnrollment(SnowUser user);
    }
}