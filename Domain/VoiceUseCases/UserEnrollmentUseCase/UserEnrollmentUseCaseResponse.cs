using Domain.Entities;

namespace Domain.VoiceUseCases.UserEnrollmentUseCase
{
    public class UserEnrollmentUseCaseResponse
    {
        public readonly int RemainingEnrollments;
        public readonly EnrollmentState PreviousEnrollmentState;
        public readonly SnowUser UserToEnroll;
        public readonly string EnrollmentPharse;

        public UserEnrollmentUseCaseResponse(
            int remainingEnrollments, 
            EnrollmentState previousEnrollmentState,
            SnowUser userToEnroll, 
            string enrollmentPharse)
        {
            this.RemainingEnrollments = remainingEnrollments;
            this.PreviousEnrollmentState = previousEnrollmentState;
            this.UserToEnroll = userToEnroll;
            this.EnrollmentPharse = enrollmentPharse;
        }
    }

    public enum EnrollmentState
    {
        Success, Failed, NotStarted
    }
}