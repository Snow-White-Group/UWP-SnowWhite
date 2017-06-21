using Domain.DefaultUserUseCase;
using Domain.Services;
using Windows.Storage;

namespace Domain.StartupUseCase
{
    public class StartupInteractor : IStartupUseCase
    {
        private readonly IDefaultUserUseCase _defaultUserInteractor;
        private readonly INoiseDetectionService _noiseDetectionService;
        private readonly IAppSettingsService _appSettingsService;
        public StartupInteractor(INoiseDetectionService noiseDetectionService, IDefaultUserUseCase defaultUserInteractor, IAppSettingsService _appSettingsService)
        {
            this._noiseDetectionService = noiseDetectionService;
            this._defaultUserInteractor = defaultUserInteractor;
            this._appSettingsService = _appSettingsService;
        }

        public void StartApplication()
        {
            _appSettingsService.GetLocalMirrorNames();
            _defaultUserInteractor.TriggerDefaultUser();
        }
    }
}