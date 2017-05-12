using Domain.Entities;

namespace Domain.VoiceUseCases.AuthenticateUserUseCase
{
    interface IAuthenticateUserUseCase
    {
        void Authenticate(IVoiceFile recordedAudio);
    }
}
