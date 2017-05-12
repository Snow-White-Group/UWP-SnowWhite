using Domain.Entities;

namespace Domain.Services
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