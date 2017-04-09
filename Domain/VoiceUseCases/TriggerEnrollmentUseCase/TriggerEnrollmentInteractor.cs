using System;
using System.Diagnostics;
using System.Threading.Tasks;
using Domain.Entities;
using Domain.Services;

namespace Domain.VoiceUseCases.TriggerEnrollmentUseCase
{
    using Domain.VoiceUseCases.NoiseDetectedUseCase;
    using Domain.VoiceUseCases.Services;
    using Domain.Boundaries;

    public class TriggerEnrollmentInteractor : ITriggerEnrollmentUseCase
    {
        private readonly IVoiceUseCasesStateService _voiceUseCasesStateService;
        private readonly IDeliveryBoundary _deliveryBoundary;
        private readonly IMirrorStateServices _mirrorStateServices;

        public TriggerEnrollmentInteractor(IVoiceUseCasesStateService voiceUseCasesStateService, IMirrorStateServices mirrorStateServices, IDeliveryBoundary deliveryBoundary)
        {
            this._voiceUseCasesStateService = voiceUseCasesStateService;
            this._mirrorStateServices = mirrorStateServices;
            this._deliveryBoundary = deliveryBoundary;
        }

        public bool TriggerEnrollment(TriggerEnrollmentRequest request)
        {
            if (!_mirrorStateServices.GetCurrentUser().IsDefaultUser 
                || _voiceUseCasesStateService.GetCurrentDetectionState() == VoiceUseCasesState.EnrollmentDetection)
            {
                return false;
            }

            _voiceUseCasesStateService.SetCurrentDetectionState(VoiceUseCasesState.EnrollmentDetection);
            _voiceUseCasesStateService.SetUserForEnrollment(request.SnowUser);
            _mirrorStateServices.SetCurrentUserTO(new MirrorUser(request.SnowUser,false,false,null));
            _deliveryBoundary.DeliverEnrollmentPage();
            return true;
        }
    }
}