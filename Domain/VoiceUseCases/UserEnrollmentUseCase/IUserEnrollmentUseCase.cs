using Domain.Entities;

namespace Domain.VoiceUseCases.UserEnrollmentUseCase
{
    public interface IUserEnrollmentUseCase
    {
        void Enroll(IVoiceFile recordedAudio);
    }
}