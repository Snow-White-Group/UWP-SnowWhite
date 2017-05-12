using Domain.Entities;

namespace Domain.VoiceUseCases.UserEnrollmentUseCase
{
    public class UserEnrollmentUseCaseResponse
    {
        public readonly int RemainingEnrollments;

        public readonly EnrollmentState LastEnrollmentState;

        public readonly SnowUser UserToEnroll;

        
    }

    public enum EnrollmentState
    {
        Success, Failed, NotStarted
    }
}