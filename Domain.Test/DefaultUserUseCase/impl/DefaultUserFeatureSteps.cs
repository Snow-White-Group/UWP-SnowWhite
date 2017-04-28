using System;
using System.Collections.Generic;
using System.Diagnostics;
using Domain.Boundaries;
using Domain.DefaultUserUseCase;
using Domain.Entities;
using Domain.Services;
using Domain.Test.VoiceUseCases.TriggerEnrollmentUseCase.impl;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TechTalk.SpecFlow;

namespace Domain.Test.DefaultUserUseCase.impl
{
    [Binding]
    public class DefaultUserFeatureSteps
    {

        private DefaultUserUseCaseInteractor _interactor;
        private MockConfigurationPageService _configurationPageService;
        private MockWeatherService _weatherService;
        private MockNewsService _newsService;
        private MockDeliveryBoundary _deliveryBoundary;
        private MockStateService _mirrorStateServices;
        private MockDefaultUserPresenter _defaultUserPresenter;
        
        [Given(@"the device gets booted")]
        public void GivenTheDeviceGetsBooted()
        {
            _configurationPageService = new MockConfigurationPageService();
            _weatherService = new MockWeatherService();
            _newsService = new MockNewsService();
            _deliveryBoundary = new MockDeliveryBoundary();
            _mirrorStateServices = new MockStateService();
            _defaultUserPresenter = new MockDefaultUserPresenter();
            _interactor = new DefaultUserUseCaseInteractor(_configurationPageService, _weatherService, _newsService,
                _deliveryBoundary, _mirrorStateServices, _defaultUserPresenter);
        }
        
        [When(@"the default user gets triggered")]
        public void WhenTheDefaultUserGetsTriggered()
        {
            _interactor.TriggerDefaultUser();
        }
        
        [Then(@"the weather should be loaded")]
        public void ThenTheWeatherShouldBeLoaded()
        {
            Assert.IsTrue(_weatherService.Called);
        }
        
        [Then(@"the news should be loaded")]
        public void ThenTheNewsShouldBeLoaded()
        {
            Assert.IsTrue(_newsService.Called);
        }
        
        [Then(@"the user should be switched to the DefaultUser")]
        public void ThenTheUserShouldBeSwitchedToTheDefaultUser()
        {
            var snowUser = new SnowUser("Dominik", "Jülg", "hello@fresh.de", "JOJOJO_ID");
            var mirrorUser = new MirrorUser(snowUser, true, true, "annoonnnyyymmmm");
            Assert.AreEqual(mirrorUser.AnnonymousId, _mirrorStateServices.GetCurrentUser().AnnonymousId);
        }
        
        [Then(@"the DefaultUserPage should be delivered")]
        public void ThenTheDefaultUserPageShouldBeDelivered()
        {
            var weather = new WeatherData(23, "Sunny", new DateTime(), new List<string>(), "Achern");
            var news = new List<News>();
            Assert.AreEqual(new DwarfData(weather, news), _defaultUserPresenter.DwarfData);
        }
    }
}
