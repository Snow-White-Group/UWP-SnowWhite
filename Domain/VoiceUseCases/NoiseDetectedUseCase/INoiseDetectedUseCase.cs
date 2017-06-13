using Domain.Services;

namespace Domain.VoiceUseCases.NoiseDetectedUseCase
{
    // see https://docs.google.com/document/d/1yUpelTJoRxF9umwHOJSW4e-bFlqAic3YuWJPYUUCpoc
    public interface INoiseDetectedUseCase
    {
        void OnNoiseCompleted(NoiseDetectedRequest noiseDetectedRequest);
        void OnNoiseDetected(INoiseEvent eEvent);
    }
}
