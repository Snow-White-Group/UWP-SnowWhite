using Domain.Entities;

namespace Domain.VoiceUseCases.NoiseDetectedUseCase
{
    public class NoiseDetectedRequest
    {
        public IVoiceFile RecordedAudio { get; set; }

        public NoiseDetectedRequest(IVoiceFile recordedAudio)
        {
            this.RecordedAudio = recordedAudio;
        }
    }
}