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

namespace Domain.Test.DefaultUserUseCase.Impl
{
    using System.Runtime.InteropServices;

    [Binding]
    public class DefaultUserFeatureSteps
    {

        private DefaultUserUseCaseInteractor interactor;
        private MockWeatherService weatherService;
        private MockNewsService newsService;
        private MockDeliveryBoundary deliveryBoundary;
        private MockStateService mirrorStateServices;
        private MockDefaultUserPresenter defaultUserPresenter;
        
        [Given(@"the device gets booted")]
        public void GivenTheDeviceGetsBooted()
        {
            this.weatherService = new MockWeatherService();
            this.newsService = new MockNewsService();
            this.deliveryBoundary = new MockDeliveryBoundary();
            this.mirrorStateServices = new MockStateService();
            this.defaultUserPresenter = new MockDefaultUserPresenter();
            this.interactor = new DefaultUserUseCaseInteractor(
                this.weatherService,
                this.newsService,
                this.deliveryBoundary,
                this.mirrorStateServices,
                this.defaultUserPresenter);
        }
        
        [When(@"the default user gets triggered")]
        public void WhenTheDefaultUserGetsTriggered()
        {
            this.interactor.TriggerDefaultUser();
        }
        
        [Then(@"the weather should be loaded")]
        public void ThenTheWeatherShouldBeLoaded()
        {
            Assert.IsTrue(this.weatherService.Called);
        }
        
        [Then(@"the news should be loaded")]
        public void ThenTheNewsShouldBeLoaded()
        {
            Assert.IsTrue(this.newsService.Called);
        }
        
        [Then(@"the user should be switched to the DefaultUser")]
        public void ThenTheUserShouldBeSwitchedToTheDefaultUser()
        {
            var snowUser = new SnowUser("Dominik", "Jülg", "hello@fresh.de", "JOJOJO_ID");
            var mirrorUser = new MirrorUser(snowUser, true, true, "annoonnnyyymmmm");
            Assert.AreEqual(mirrorUser.AnnonymousId, this.mirrorStateServices.GetCurrentUser().AnnonymousId);
        }
        
        [Then(@"the DefaultUserPage should be delivered")]
        public void ThenTheDefaultUserPageShouldBeDelivered()
        {
          Assert.IsTrue(this.deliveryBoundary.HasBeenCalled);
        }
    }
}
