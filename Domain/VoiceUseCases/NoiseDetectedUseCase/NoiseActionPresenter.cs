using System.Threading.Tasks;

namespace Domain.VoiceUseCases.NoiseDetectedUseCase
{
    public interface INoiseActionPresenter
    {
        Task OnPresent(INoiseEvent eEvent);
    }
}