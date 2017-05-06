using Domain.Entities;

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