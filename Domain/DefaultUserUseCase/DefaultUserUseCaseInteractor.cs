using System.Linq;
using Domain.Boundaries;
using Domain.Entities;
using Domain.Services;

namespace Domain.DefaultUserUseCase
{
    public class DefaultUserUseCaseInteractor : IDefaultUserUseCase
    {
        private readonly IConfigurationPageService _configurationPageService;
        private readonly IWeatherService _weatherService;
        private readonly INewsService _newsService;
        private readonly IDeliveryBoundary _deliveryBoundary;
        private readonly IMirrorStateServices _mirrorStateServices;
        private readonly IDefaultUserPresenter _defaultUserPresenter;

        public DefaultUserUseCaseInteractor(IConfigurationPageService configurationPageService, IWeatherService weatherService, INewsService newsService, 
            IDeliveryBoundary deliveryBoundary, IMirrorStateServices mirrorStateServices, IDefaultUserPresenter defaultUserPresenter)
        {
            _configurationPageService = configurationPageService;
            _weatherService = weatherService;
            _newsService = newsService;
            _deliveryBoundary = deliveryBoundary;
            _mirrorStateServices = mirrorStateServices;
            _defaultUserPresenter = defaultUserPresenter;
        }

        public async void TriggerDefaultUser()
        {
            var weather = _weatherService.LoadWeatherData();
            var newsSources = await _newsService.GetSources().ConfigureAwait(false);
            var news = await _newsService.GetNews(newsSources.Select(s => s.Name).ToArray()).ConfigureAwait(false);

            _defaultUserPresenter.OnPresent(new DwarfData(weather, news));
            await _deliveryBoundary.DeliverDefaultUserPage().ConfigureAwait(false);
            _mirrorStateServices.SetCurrentUserTO(_configurationPageService.LoadDefaultUser());
        }
    }
}