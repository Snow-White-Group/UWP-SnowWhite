using Domain.Services;

namespace Domain.VoiceUseCases.NoiseDetectedUseCase
{
    // see https://docs.google.com/document/d/1yUpelTJoRxF9umwHOJSW4e-bFlqAic3YuWJPYUUCpoc
    interface INoiseDetectedUseCase
    {
        void OnNoiseDetected(NoiseDetectedRequest noiseDetectedRequest);
    }
}
