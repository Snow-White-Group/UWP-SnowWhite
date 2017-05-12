using System;
using Domain.Entities;
using Domain.VoiceUseCases.Services;
using Domain.VoiceUseCases.TriggerEnrollmentUseCase;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TechTalk.SpecFlow;

namespace Domain.Test.VoiceUseCases.TriggerEnrollmentUseCase.Impl
{
    [Binding]
    public class TriggerEnrollmentFeatureSteps
    {
        private readonly MockStateService mockStateService;
        private readonly MockDeliveryBoundary mockDeliveryBoundary;

        private readonly SnowUser defaultSnowUser;
        private readonly SnowUser someSnowUser;
        private readonly MirrorUser defaultMirrorUser;
        private readonly MirrorUser someMirrorUser;


        private readonly TriggerEnrollmentInteractor interactor;

        private bool useCaseResult;

        private VoiceUseCasesState stateBefore;

        public TriggerEnrollmentFeatureSteps()
        {
            this.mockStateService = new MockStateService();
            this.mockDeliveryBoundary = new MockDeliveryBoundary();
            this.defaultSnowUser = new SnowUser("Default", "Default", "test@test.de", "SOME_ID");
            this.someSnowUser = new SnowUser("Cem", "Freimoser", "test@test.de", "SOME_ID");
            this.defaultMirrorUser = new MirrorUser(this.defaultSnowUser, true, true, null);
            this.someMirrorUser = new MirrorUser(this.someSnowUser, false, true, null);
            this.interactor = new TriggerEnrollmentInteractor(this.mockStateService, this.mockStateService, this.mockDeliveryBoundary);
        }

        [Given(@"The mirror is currently displaying the default user")]
        public void GivenTheMirrorIsCurrentlyDisplayingTheDefaultUser()
        {
            this.mockStateService.SetCurrentUserTo(this.defaultMirrorUser);
        }

        [Given(@"The mirror is currently displaying some user")]
        public void GivenTheMirrorIsCurrentlyDisplayingSomeUser()
        {
            this.mockStateService.SetCurrentUserTo(this.someMirrorUser);
        }

        [Given(@"the miror state is detection")]
        public void GivenTheMirorStateIsDetection()
        {
            this.mockStateService.SetCurrentDetectionState(VoiceUseCasesState.UserDetection);
        }

        [Given(@"The mirror is currently enrolling some user")]
        public void GivenTheMirrorIsCurrentlyEnrollingSomeUser()
        {
            this.mockStateService.SetCurrentUserTo(this.someMirrorUser);
            this.mockStateService.SetCurrentDetectionState(VoiceUseCasesState.EnrollmentDetection);
        }

        [Given(@"the mirror state is detection")]
        public void GivenTheMirrorStateIsDetection()
        {
            this.mockStateService.SetCurrentDetectionState(VoiceUseCasesState.UserDetection);
        }

        [When(@"The gateway passes a EnrollmentRequest to the TriggerEnrollmentInteractor")]
        public void WhenTheGatewayPassesAEnrollmentRequestToTheTriggerEnrollmentInteractor()
        {
            this.stateBefore = this.mockStateService.GetCurrentDetectionState();
            var request = new TriggerEnrollmentRequest(this.someSnowUser);
            this.useCaseResult = this.interactor.TriggerEnrollment(request);
        }

        [Then(@"The mirror should show the enrollment page")]
        public void ThenTheMirrorShouldShowTheEnrollmentPage()
        {
            Assert.IsTrue(this.useCaseResult);
            Assert.IsTrue(this.mockDeliveryBoundary.HasBeenCalled);
        }

        [Then(@"The mirror state should switch to enrollment")]
        public void ThenTheMirrorStateShouldSwitchToEnrollment()
        {
            var currentState = this.mockStateService.GetCurrentDetectionState();
            Assert.AreEqual(VoiceUseCasesState.EnrollmentDetection, currentState);
        }

        [Then(@"The mirror state should permit the user to enroll")]
        public void ThenTheMirrorStateShouldPermitTheUserToEnroll()
        {
            var currentUser = this.mockStateService.GetCurrentUser();
            Assert.AreEqual(this.someSnowUser, currentUser.SnowUser);
        }

        [Then(@"The mirror should reject this trigger")]
        public void ThenTheMirrorShouldRejectThisTrigger()
        {
            Assert.IsFalse(this.useCaseResult);
        }

        [Then(@"No state should be changed")]
        public void ThenNoStateShouldBeChanged()
        {
            var currentState = this.mockStateService.GetCurrentDetectionState();
            Assert.AreEqual(this.stateBefore, currentState);
        }
    }
}