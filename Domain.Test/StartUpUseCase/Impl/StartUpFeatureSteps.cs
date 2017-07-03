using Domain.DefaultUserUseCase;
using Domain.SetUpUseCase;
using Domain.StartupUseCase;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using TechTalk.SpecFlow;

namespace Domain.Test.StartUpUseCase.Impl
{
    [Binding]
    public class StartUpFeatureSteps
    {
        public IStartupUseCase su_interactor;
        public MockDefaultUser mockDefaultUser;
        public MockAppSettings mockSettings;
        public MockSetUP mockSetUP;


        [Given(@"snow white core is started")]
        public void GivenSnowWhiteCoreIsStarted()
        {
          mockSettings = new MockAppSettings();
          mockDefaultUser = new MockDefaultUser();
          mockSetUP = new MockSetUP();
          su_interactor = new StartupInteractor(null, mockDefaultUser, mockSettings, mockSetUP);
        }
        
        [When(@"no mirror name gets found")]
        public void WhenNoMirrorNameGetsFound()
        {
            mockSettings.hasMirrorName = false;
            su_interactor.StartApplication();
        }

        [When(@"mirror names are found")]
        public void WhenMirrorNamesAreFound()
        {
            mockSettings.hasMirrorName = true;
            su_interactor.StartApplication();
        }

        [Then(@"setupUC should be triggerd")]
        public void ThenSetupUCShouldBeTriggerd()
        {
            Assert.IsTrue(mockSetUP.hasBeenTriggerd);
        }
        
        [Then(@"the default user should be triggerd")]
        public void ThenTheDefaultUserShouldBeTriggerd()
        {
            Assert.IsTrue(mockDefaultUser.hasBeenTriggerd);
        }
    }
}
