using System;
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
        private readonly MockStateService _mockStateService;
        private readonly MockBoundary _mockBoundary;

        private readonly SnowUser _defaultSnowUser;
        private readonly SnowUser _someSnowUser;
        private readonly MirrorUser _defaultMirrorUser;
        private readonly MirrorUser _someMirrorUser;


        private readonly TriggerEnrollmentInteractor _interactor;

        private bool _useCaseResult;
        private VoiceUseCasesState _stateBefore;
        public TriggerEnrollmentFeatureSteps()
        {
            _mockStateService = new MockStateService();
            _mockBoundary = new MockBoundary();
            _defaultSnowUser = new SnowUser("Default", "Default", "test@test.de", "SOME_ID");
            _someSnowUser = new SnowUser("Cem", "Freimoser", "test@test.de", "SOME_ID");
            _defaultMirrorUser = new MirrorUser(_defaultSnowUser, true, true, null);
            _someMirrorUser = new MirrorUser(_someSnowUser, false, true, null);
            _interactor = new TriggerEnrollmentInteractor(_mockStateService, _mockStateService, _mockBoundary);
        }

        [Given(@"The mirror is currently displaying the deault user")]
        public void GivenTheMirrorIsCurrentlyDisplayingTheDeaultUser()
        {
            _mockStateService.SetCurrentUserTO(_defaultMirrorUser);
        }

        [Given(@"The mirror is currently displaying some user")]
        public void GivenTheMirrorIsCurrentlyDisplayingSomeUser()
        {
            _mockStateService.SetCurrentUserTO(_someMirrorUser);
        }

        [Given(@"the miror state is detection")]
        public void GivenTheMirorStateIsDetection()
        {
            _mockStateService.SetCurrentDetectionState(VoiceUseCasesState.UserDetection);
        }

        [Given(@"The mirror is currently enrolling some user")]
        public void GivenTheMirrorIsCurrentlyEnrollingSomeUser()
        {
            _mockStateService.SetCurrentUserTO(_someMirrorUser);
            _mockStateService.SetCurrentDetectionState(VoiceUseCasesState.EnrollmentDetection);
        }

        [Given(@"the mirror state is detection")]
        public void GivenTheMirrorStateIsDetection()
        {
            _mockStateService.SetCurrentDetectionState(VoiceUseCasesState.UserDetection);
        }

        [When(@"The gateway passes a EnrollmentRequest to the TriggerEnrollmentInteractor")]
        public void WhenTheGatewayPassesAEnrollmentRequestToTheTriggerEnrollmentInteractor()
        {
            _stateBefore = _mockStateService.GetCurrentDetectionState();
            var request = new TriggerEnrollmentRequest(_someSnowUser);
            _useCaseResult = _interactor.TriggerEnrollment(request);
        }

        [Then(@"The mirror should show the enrollment page")]
        public void ThenTheMirrorShouldShowTheEnrollmentPage()
        {
            Assert.IsTrue(_useCaseResult);
            Assert.IsTrue(_mockBoundary.HasBeenCalled);
        }

        [Then(@"The mirror state should switch to enrollment")]
        public void ThenTheMirrorStateShouldSwitchToEnrollment()
        {
            var currentState = _mockStateService.GetCurrentDetectionState();
            Assert.AreEqual(VoiceUseCasesState.EnrollmentDetection, currentState);
        }

        [Then(@"The mirror state should persit the user to enroll")]
        public void ThenTheMirrorStateShouldPersitTheUserToEnroll()
        {
            var currentUser = _mockStateService.GetCurrentUser();
            Assert.AreEqual(_someSnowUser, currentUser.SnowUser);
        }

        [Then(@"The mirror should reject this trigger")]
        public void ThenTheMirrorShouldRejectThisTrigger()
        {
            Assert.IsFalse(_useCaseResult);
        }

        [Then(@"No state should be changed")]
        public void ThenNoStateShouldBeChanged()
        {
            var currentState = _mockStateService.GetCurrentDetectionState();
            Assert.AreEqual(_stateBefore, currentState);
        }
    }
}