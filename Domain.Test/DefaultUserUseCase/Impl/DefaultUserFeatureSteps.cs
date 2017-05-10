using System;
using System.Collections.Generic;
using System.Diagnostics;
using Domain.Boundaries;
using Domain.DefaultUserUseCase;
using Domain.Entities;
using Domain.Services;
using Domain.Test.VoiceUseCases.TriggerEnrollmentUseCase.Impl;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TechTalk.SpecFlow;

namespace Domain.Test.DefaultUserUseCase.impl
{
    [Binding]
    public class DefaultUserFeatureSteps
    {

        private DefaultUserUseCaseInteractor _interactor;
        private MockWeatherService _weatherService;
        private MockNewsService _newsService;
        private MockDeliveryBoundary _deliveryBoundary;
        private MockStateService _mirrorStateServices;
        private MockDefaultUserPresenter _defaultUserPresenter;
        
        [Given(@"the device gets booted")]
        public void GivenTheDeviceGetsBooted()
        {
            this._weatherService = new MockWeatherService();
            this._newsService = new MockNewsService();
            this._deliveryBoundary = new MockDeliveryBoundary();
            this._mirrorStateServices = new MockStateService();
            this._defaultUserPresenter = new MockDefaultUserPresenter();
            this._interactor = new DefaultUserUseCaseInteractor(
                this._weatherService,
                this._newsService,
                this._deliveryBoundary,
                this._mirrorStateServices,
                this._defaultUserPresenter);
        }
        
        [When(@"the default user gets triggered")]
        public void WhenTheDefaultUserGetsTriggered()
        {
            this._interactor.TriggerDefaultUser();
        }
        
        [Then(@"the weather should be loaded")]
        public void ThenTheWeatherShouldBeLoaded()
        {
            Assert.IsTrue(this._weatherService.Called);
        }
        
        [Then(@"the news should be loaded")]
        public void ThenTheNewsShouldBeLoaded()
        {
            //TODO FIX ME!!!
            //Assert.IsTrue(this._newsService.Called);
        }
        
        [Then(@"the user should be switched to the DefaultUser")]
        public void ThenTheUserShouldBeSwitchedToTheDefaultUser()
        {
            var snowUser = new SnowUser("Dominik", "Jülg", "hello@fresh.de", "JOJOJO_ID");
            var mirrorUser = new MirrorUser(snowUser, true, true, "annoonnnyyymmmm");
            Assert.AreEqual(mirrorUser.AnnonymousId, this._mirrorStateServices.GetCurrentUser().AnnonymousId);
        }
        
        [Then(@"the DefaultUserPage should be delivered")]
        public void ThenTheDefaultUserPageShouldBeDelivered()
        {
            var weather = new WeatherForecast();
            weather.city = new City();
            weather.city.name = "Karlsruhe";
            var news = new List<News>();
            Assert.AreEqual(weather.city.name, this._defaultUserPresenter.DwarfData.Weather.city.name);
        }
    }
}
