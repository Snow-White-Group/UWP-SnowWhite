﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;
using Domain.Services;
using Domain.VoiceUseCases.Services;

namespace Domain.Test.VoiceUseCases.TriggerEnrollmentUseCase.Impl
{
    public class MockStateService : IVoiceUseCasesStateService, IMirrorStateServices
    {
        private VoiceUseCasesState mockState;
        private SnowUser mockSnowUser;
        private MirrorUser mockMirrorUser;

        public VoiceUseCasesState GetCurrentDetectionState()
        {
            return this.mockState;
        }

        public void SetCurrentDetectionState(VoiceUseCasesState state)
        {
            this.mockState = state;
        }

        public SnowUser GetUserForEnrollment()
        {
            return this.mockSnowUser;
        }

        public void SetUserForEnrollment(SnowUser user)
        {
            this.mockSnowUser = user;
        }

        public void SetCurrentUserTO(MirrorUser user)
        {
            this.mockMirrorUser = user;
        }

        public MirrorUser GetCurrentUser()
        {
            return this.mockMirrorUser;
        }

        public MirrorUser LoadDefaultUser()
        {
            throw new NotImplementedException();
        }

        public MirrorUser LoadDefaultUser()
        {
            throw new NotImplementedException();
        }
    }
}
