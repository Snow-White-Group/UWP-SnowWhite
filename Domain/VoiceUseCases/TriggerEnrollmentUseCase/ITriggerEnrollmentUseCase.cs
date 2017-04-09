using System;
using System.Threading.Tasks;

namespace Domain.VoiceUseCases.TriggerEnrollmentUseCase
{
    public interface ITriggerEnrollmentUseCase
    {
        bool TriggerEnrollment(TriggerEnrollmentRequest request);
    }
}