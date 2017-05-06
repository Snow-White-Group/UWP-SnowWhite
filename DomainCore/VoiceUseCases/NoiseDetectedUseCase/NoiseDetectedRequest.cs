namespace Domain.VoiceUseCases.NoiseDetectedUseCase
{
    using Entities;
    public class NoiseDetectedRequest
    {
        public IVoiceFile RecoredAudio { get; set; }

        public NoiseDetectedRequest(IVoiceFile recoredAudio)
        {
            this.RecoredAudio = recoredAudio;
        }
    }
}