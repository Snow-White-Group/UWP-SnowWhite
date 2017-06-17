using Domain.DefaultUserUseCase;
using Domain.Services;

namespace Domain.StartupUseCase
{
    public class StartupInteractor : IStartupUseCase
    {
        private readonly IDefaultUserUseCase _defaultUserInteractor;
        private readonly INoiseDetectionService _noiseDetectionService;
        public StartupInteractor(INoiseDetectionService noiseDetectionService, IDefaultUserUseCase defaultUserInteractor)
        {
            this._noiseDetectionService = noiseDetectionService;
            this._defaultUserInteractor = defaultUserInteractor;
        }

        public void StartApplication()
        {
            _defaultUserInteractor.TriggerDefaultUser();
        }
    }
}