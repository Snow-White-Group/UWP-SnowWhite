using Domain.Entities;
using Domain.HandshakeUseCase;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using TechTalk.SpecFlow;

namespace Domain.Test.HandshakeUseCase.Impl
{
    [Binding]
    public class HandShakeUseCaseSteps
    {
        public IHandshakeUseCase handshake;
        public MockAppSettings mockSettings;
        public MockCloudCommunicationService mockCommunicationService;
        public MockdefaultUser defaultuser;
        public MirrorNames names;

        [Given(@"The Handshake use case gets triggert")]
        public void GivenTheHandshakeUseCaseGetsTriggert()
        {
            mockSettings = new MockAppSettings();
            mockCommunicationService = new MockCloudCommunicationService();
            defaultuser = new MockdefaultUser ();
            handshake = new HandshakeInteractor(mockSettings, mockCommunicationService, defaultuser);
        }
        
        [Then(@"snow white core should established a connection to snow white cloud")]
        public void ThenSnowWhiteCoreShouldEstablishedAConnectionTaoSnowWhiteCloud()
        {
            handshake.handshake();
        }
        
        [Then(@"snow white core should get a display name from snow white cloud")]
        public void ThenSnowWhiteCoreShouldGetADisplayNameFromSnowWhiteCloud()
        {
            var task = mockCommunicationService.GetMirrorNames();
            task.Wait();
            names = task.Result;
            Assert.IsNotNull(names.DisplayName);
        }
        
        [Then(@"snow white core should get a secret name from snow white cloud")]
        public void ThenSnowWhiteCoreShouldGetASecretNameFromSnowWhiteCloud()
        {
            Assert.IsNotNull(names.SecretName);
        }

        [Then(@"snow white core should store this infromation in local APP Settings")]
        public void ThenSnowWhiteCoreShouldStoreThisInfromationInLocalAPPSettings()
        {
            mockSettings.PutLocalMirrorNames(names);
            Assert.AreEqual(names, mockSettings.GetLocalMirrorNames());
        }

        [Then(@"the defaultuser use case should be triggerd")]
        public void ThenTheStartupUseCaseShouldBeTriggerd()
        {
            Assert.IsTrue(defaultuser.hasBeenTriggerd);
        }
    }
}
