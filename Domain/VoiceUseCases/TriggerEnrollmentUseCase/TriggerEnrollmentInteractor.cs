namespace Domain.VoiceUseCases.TriggerEnrollmentUseCase
{
    using Domain.VoiceUseCases.NoiseDetectedUseCase;
    using Domain.VoiceUseCases.Services;
    using Domain.Boundaries;

    public class TriggerEnrollmentInteractor : ITriggerEnrollmentUseCase
    {
        private readonly IVoiceUseCasesStateService voiceUseCasesStateService;
        private readonly IDeliveryBoundary deliveryBoundary;

        public TriggerEnrollmentInteractor(IVoiceUseCasesStateService voiceUseCasesStateService, IDeliveryBoundary deliveryBoundary)
        {
            this.voiceUseCasesStateService = voiceUseCasesStateService;
            this.deliveryBoundary = deliveryBoundary;
        }

        public void TriggerEnrollment()
        {
            voiceUseCasesStateService.SetCurrentDetectionState(VoiceUseCasesState.EnrollmentDetection);
            deliveryBoundary.DeliverEnrollmentPage();
        }
    }
}