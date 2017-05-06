using Domain.Entities;

namespace Domain.VoiceUseCases.TriggerEnrollmentUseCase
{
    public class TriggerEnrollmentRequest
    {
        public SnowUser SnowUser { get; set; }

        public TriggerEnrollmentRequest(SnowUser user)
        {
            this.SnowUser = user;
        }

    }
}