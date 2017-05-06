using System;
using System.Threading.Tasks;

namespace Domain.VoiceUseCases.TriggerEnrollmentUseCase
{
    //see https://docs.google.com/document/d/1dhc9n3fpbLaAiir7sA_XEnKaz8BJPxDHfbDc1D3BW2k/edit
    public interface ITriggerEnrollmentUseCase
    {
        bool TriggerEnrollment(TriggerEnrollmentRequest request);
    }
}