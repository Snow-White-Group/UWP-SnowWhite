using Domain.DefaultUserUseCase;
using Domain.Services;
using Domain.SetUpUseCase;
using Windows.Storage;

namespace Domain.StartupUseCase
{
    public class StartupInteractor : IStartupUseCase
    {
        private readonly IDefaultUserUseCase _defaultUserInteractor;
        private readonly INoiseDetectionService _noiseDetectionService;
        private readonly IAppSettingsService _appSettingsService;
        private readonly IHandShakeUseCase _setupInteractor;


        public StartupInteractor(INoiseDetectionService noiseDetectionService, 
            IDefaultUserUseCase defaultUserInteractor,
            IAppSettingsService appSettingsService, 
            IHandShakeUseCase setupInteractor)
        {
            this._noiseDetectionService = noiseDetectionService;
            this._defaultUserInteractor = defaultUserInteractor;
            this._appSettingsService = appSettingsService;
            this._setupInteractor = setupInteractor;

        }

        public void StartApplication()
        {
            if(_appSettingsService.GetLocalMirrorNames() != null) { 
                _appSettingsService.GetLocalMirrorNames();
                _defaultUserInteractor.TriggerDefaultUser();
            } else
            {
                _setupInteractor.SetUpCore();
            }
        }
    }
}