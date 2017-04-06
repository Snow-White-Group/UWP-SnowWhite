namespace Domain.VoiceUseCases.NoiseDetectedUseCase
{
    using System.Threading.Tasks;

    public interface INoiseDetectedUseCase
    {
        Task OnNoiseDetected(NoiseDetectedRequest noiseDetectedRequest);
    }
}