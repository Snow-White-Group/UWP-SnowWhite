using System.Linq;
using Domain.Boundaries;
using Domain.Entities;
using Domain.Services;
using System;
using System.Diagnostics;

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
        private readonly IHandshakeService _handshakeService;

        public DefaultUserUseCaseInteractor(
            IWeatherService weatherService, 
            INewsService newsService, 
            IDeliveryBoundary deliveryBoundary,
            IMirrorStateServices mirrorStateServices, 
            IDefaultUserPresenter defaultUserPresenter,
            IAppSettingsService appSettingsService,
            IHandshakeService handshakeService
            )
        {
            _weatherService = weatherService;
            _newsService = newsService;
            _deliveryBoundary = deliveryBoundary;
            _mirrorStateServices = mirrorStateServices;
            _defaultUserPresenter = defaultUserPresenter;
            _appSettingsService = appSettingsService;
            _handshakeService = handshakeService;
        }

        public async void TriggerDefaultUser()
        {
            var weather = await _weatherService.GetWeather("Karlsruhe");
            var newsSources = await _newsService.GetSources("en");
            var news = await _newsService.GetNews(newsSources);
            var displayName = (await _appSettingsService.GetLocalMirrorNames()).DisplayName;
            var secretName = (await _appSettingsService.GetLocalMirrorNames()).SecretName;

            await _deliveryBoundary.DeliverDefaultUserPage().ConfigureAwait(false);
            _defaultUserPresenter.OnPresent(new DefaultUserResponse(weather, news, displayName));
            _mirrorStateServices.SetCurrentUserTo(_mirrorStateServices.LoadDefaultUser());
            await _handshakeService.CheckPostfach(secretName);
        }
    }
}