namespace Domain.VoiceUseCases.NoiseDetectedUseCase
{
    using System.Threading.Tasks;

    // UseCase https://docs.google.com/document/d/1yUpelTJoRxF9umwHOJSW4e-bFlqAic3YuWJPYUUCpoc/edit?usp=sharing
    public interface INoiseDetectedUseCase
    {
        Task OnNoiseDetected(NoiseDetectedRequest noiseDetectedRequest);
    }
}