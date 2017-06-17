using Domain.Services;

namespace Domain.VoiceUseCases.NoiseDetectedUseCase
{
    public class TempNoiseDetectedInteractor : INoiseDetectedUseCase
    {
        private readonly INoiseActionPresenter _noiseActionPresenter;
        public TempNoiseDetectedInteractor(INoiseActionPresenter noiseActionPresenter)
        {
            _noiseActionPresenter = noiseActionPresenter;
        }


        public void OnNoiseCompleted(NoiseDetectedRequest noiseDetectedRequest)
        {
            throw new System.NotImplementedException();
        }

        public void OnNoiseDetected(INoiseEvent eEvent)
        {
            _noiseActionPresenter.OnPresent(eEvent);
        }
    }
}