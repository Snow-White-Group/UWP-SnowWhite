using Domain.VoiceUseCases.Services;

namespace Domain.VoiceUseCases.NoiseDetectedUseCase
{
    public interface IVoiceUseCasesStateService
    {
        VoiceUseCasesState GetCurrentDetectionState();

        void SetCurrentDetectionState(VoiceUseCasesState state);
    }
}