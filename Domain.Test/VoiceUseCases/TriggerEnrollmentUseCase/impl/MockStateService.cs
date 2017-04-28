using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;
using Domain.Services;
using Domain.VoiceUseCases.Services;

namespace Domain.Test.VoiceUseCases.TriggerEnrollmentUseCase.impl
{
    class MockStateService : IVoiceUseCasesStateService, IMirrorStateServices
    {
        private VoiceUseCasesState _mockState;
        private SnowUser _mockSnowUser;
        private MirrorUser _mockMirrorUser;

        public VoiceUseCasesState GetCurrentDetectionState()
        {
            return _mockState;
        }

        public void SetCurrentDetectionState(VoiceUseCasesState state)
        {
            this._mockState = state;
        }

        public SnowUser GetUserForEnrollment()
        {
            return _mockSnowUser;
        }

        public void SetUserForEnrollment(SnowUser user)
        {
            this._mockSnowUser = user;
        }

        public void SetCurrentUserTO(MirrorUser user)
        {
            this._mockMirrorUser = user;
        }

        public MirrorUser GetCurrentUser()
        {
            return _mockMirrorUser;
        }
    }
}
