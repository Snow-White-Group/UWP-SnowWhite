using System.Collections.Generic;
using System.Linq;
using Domain.Boundaries;
using Domain.Entities;
using Domain.Services;

namespace Domain.DefaultUserUseCase
{
    public class DefaultUserUseCaseInteractor : IDefaultUserUseCase
    {
        private static readonly string LANGUAGE_DE = "de";

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

        public void TriggerDefaultUser()
        {
            WeatherData weather = _weatherService.LoadWeatherData();
            List<NewsSource> newsSources = _newsService.GetSources(LANGUAGE_DE).Result; // verwende ich den Task so richtig?

            // @mario sind die sources einfach die urls?
            // @mario eigentlich nicht schön string[] zu übergeben das sollte man vll kapseln
            // TODO @mario BROKEN DA NUR URL ÜBERGEBEN WIRD PLS FIX
            List<News> news = _newsService.GetNews(newsSources.Select(s => s.URL).ToArray()).Result; // verwende ich den Task so richtig?

            _defaultUserPresenter.OnPresent(weather, news);
            _deliveryBoundary.DeliverDefaultUserPage();
            _mirrorStateServices.SetCurrentUserTO(_configurationPageService.LoadDefaultUser());
        }
    }
}
