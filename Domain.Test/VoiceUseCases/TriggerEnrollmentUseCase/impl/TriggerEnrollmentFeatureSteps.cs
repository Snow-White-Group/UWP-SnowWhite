using Domain.Entities;
using Domain.VoiceUseCases.Services;
using Domain.VoiceUseCases.TriggerEnrollmentUseCase;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TechTalk.SpecFlow;

namespace Domain.Test.VoiceUseCases.TriggerEnrollmentUseCase.impl
{
    [Binding]
    public class TriggerEnrollmentFeatureSteps
    {
        private MockStateService _mockStateService;
        private MockBoundary _mockBoundary;
        private TriggerEnrollmentInteractor _interactor;
        [Given(@"The mirror is currently displaying the deault mockSnowUser")]
        public void GivenTheMirrorIsCurrentlyDisplayingTheDeaultUser()
        {
            _mockBoundary = new MockBoundary();
            _mockStateService = new MockStateService();
            _interactor = new TriggerEnrollmentInteractor(_mockStateService, _mockStateService, _mockBoundary);

            Assert.AreNotEqual(null,_mockStateService);
            Assert.AreNotEqual(null,_interactor);
            Assert.AreNotEqual(null,_mockBoundary);

            var defaultUser = new SnowUser("Default", "Default", "test@test.de", "SOME_ID");
            var user = new MirrorUser(defaultUser, true,true,"sdkdkasdasdas");

            _mockStateService.SetCurrentUserTO(user);
            _mockStateService.SetCurrentDetectionState(VoiceUseCasesState.UserDetection);
        }
        
        [When(@"The gateway passes a EnrollmentRequest")]
        public void WhenTheGatewayPassesAEnrollmentRequest()
        {
            var user = new SnowUser("Cem", "Freimoser", "test@test.de","SOME_ID");
            var request = new TriggerEnrollmentRequest(user);
            var hasBeenTriggerd = _interactor.TriggerEnrollment(request);
            Assert.IsTrue(hasBeenTriggerd);
        }
        
        [Then(@"The mirror should show the enrollment page")]
        public void ThenTheMirrorShouldShowTheEnrollmentPage()
        {
            Assert.IsTrue(_mockBoundary.HasBeenCalled);
        }
        
        [Then(@"The mirror mockState should switch to enrollment")]
        public void ThenTheMirrorStateShouldSwitchToEnrollment()
        {
            var currentState = _mockStateService.GetCurrentDetectionState();
            Assert.AreEqual(VoiceUseCasesState.EnrollmentDetection,currentState);
        }
        
        [Then(@"The mirror mockState should persit the mockSnowUser to enroll")]
        public void ThenTheMirrorStateShouldPersitTheUserToEnroll()
        {
            var user = _mockStateService.GetCurrentUser().SnowUser;
            Assert.AreEqual("Cem", user.FirstName);
            Assert.AreEqual("Freimoser", user.LastName);

        }
    }
}
