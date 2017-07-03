using Domain.Boundaries;
using Domain.Services;

namespace Domain.DefaultUserUseCase
{
    public class DefaultUserUseCaseInteractor : IDefaultUserUseCase
    {
        private readonly IWeatherService _weatherService;
        private readonly INewsService _newsService;
        private readonly IDeliveryBoundary _deliveryBoundary;
        private readonly IMirrorStateServices _mirrorStateServices;
        private readonly IDefaultUserPresenter _defaultUserPresenter;
        private readonly IAppSettingsService _appSettingsService;

        public DefaultUserUseCaseInteractor(
            IWeatherService weatherService, 
            INewsService newsService, 
            IDeliveryBoundary deliveryBoundary,
            IMirrorStateServices mirrorStateServices, 
            IDefaultUserPresenter defaultUserPresenter,
            IAppSettingsService appSettingsService)
        {
            _weatherService = weatherService;
            _newsService = newsService;
            _deliveryBoundary = deliveryBoundary;
            _mirrorStateServices = mirrorStateServices;
            _defaultUserPresenter = defaultUserPresenter;
            _appSettingsService = appSettingsService;
        }

        public async void TriggerDefaultUser()
        {
            var weather = await _weatherService.GetWeather("Karlsruhe");
            var newsSources = await _newsService.GetSources("en");
            var news = await _newsService.GetNews(newsSources);
            var displayName = ( _appSettingsService.GetLocalMirrorNames()).DisplayName;
            var secretName = ( _appSettingsService.GetLocalMirrorNames()).SecretName;

            //List<MirrorAction> actions = new List<MirrorAction>();

            //Task postfachTask = Task.Run(async () =>
            //{
            //    actions = await _handshakeService.CheckPostfach(secretName);
                
            //});

            //// background task in uwp isn't that easy...no time
            //await Task.Run(() => {
            //    actions = _handshakeService.CheckPostfach(secretName).Result;
            //    Task.Delay(6000);
            //});

            await _deliveryBoundary.DeliverDefaultUserPage().ConfigureAwait(false);
            _defaultUserPresenter.OnPresent(new DefaultUserResponse(weather, news, displayName));
            _mirrorStateServices.SetCurrentUserTo(_mirrorStateServices.LoadDefaultUser());

            //foreach(var action in actions)
            //{
            //    if (action.TargetAction == Entities.Action.Handshake)
            //    {
            //        _mirrorStateServices.SetCurrentUserTo(
            //            new MirrorUser(new SnowUser(action.User.FirstName, action.User.LastName, action.User.Email, action.User.SnowId),
            //            false,
            //            true,
            //            null
            //        ));
            //    }
            //    else
            //    {
            //        _mirrorStateServices.SetCurrentUserTo(_mirrorStateServices.LoadDefaultUser());
            //    }
            //}
        }
    }
}