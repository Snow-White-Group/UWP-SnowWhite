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

        public DefaultUserUseCaseInteractor(
            IWeatherService weatherService, 
            INewsService newsService, 
            IDeliveryBoundary deliveryBoundary,
            IMirrorStateServices mirrorStateServices, 
            IDefaultUserPresenter defaultUserPresenter)
        {
            _weatherService = weatherService;
            _newsService = newsService;
            _deliveryBoundary = deliveryBoundary;
            _mirrorStateServices = mirrorStateServices;
            _defaultUserPresenter = defaultUserPresenter;
        }

        public async void TriggerDefaultUser()
        {
            // warum?!
            //var weatherdata = await _weatherService.LoadWeatherData("Karlsruhe");
            var weather = await _weatherService.GetWeather("Karlsruhe");
            var newsSources = await _newsService.GetSources();
            var news = await _newsService.GetNews(newsSources);

            await _deliveryBoundary.DeliverDefaultUserPage().ConfigureAwait(false);
            _defaultUserPresenter.OnPresent(new DwarfData(null, news));
            _mirrorStateServices.SetCurrentUserTO(_mirrorStateServices.LoadDefaultUser());
        }
    }
}