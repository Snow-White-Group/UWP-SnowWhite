using System;
using Domain.Services;
using Domain.VoiceUseCases.AuthenticateUserUseCase;
using Domain.VoiceUseCases.UserEnrollmentUseCase;

namespace Domain.VoiceUseCases.NoiseDetectedUseCase
{
    internal class NoiseDetectedInteractor : INoiseDetectedUseCase
    {
        private readonly IMirrorStateServices _mirrorStateServices;
        private readonly IUserEnrollmentUseCase _userEnrollmentUseCase;
        private readonly IAuthenticateUserUseCase _authenticateUserUseCase;

        public NoiseDetectedInteractor(IMirrorStateServices mirrorStateServices, IUserEnrollmentUseCase userEnrollmentUseCase, IAuthenticateUserUseCase authenticateUserUseCase)
        {
            _mirrorStateServices = mirrorStateServices;
            _userEnrollmentUseCase = userEnrollmentUseCase;
            _authenticateUserUseCase = authenticateUserUseCase;
        }

        public void OnNoiseCompleted(NoiseDetectedRequest noiseDetectedRequest)
        {
            //if a user is logged in now change of state!
            if (!_mirrorStateServices.GetCurrentUser().IsDefaultUser) return;

            switch (_mirrorStateServices.GetCurrentDetectionState())
            {
                case VoiceUseCasesState.UserDetection:
                    _authenticateUserUseCase.Authenticate(noiseDetectedRequest.RecordedAudio);
                    break;
                case VoiceUseCasesState.EnrollmentDetection:
                    _userEnrollmentUseCase.Enroll(noiseDetectedRequest.RecordedAudio);
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        public void OnNoiseDetected(INoiseEvent eEvent)
        {
            throw new NotImplementedException();
        }
    }
}
