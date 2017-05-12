using Domain.Entities;
using Domain.Services;
using Domain.VoiceUseCases.Services;

namespace ServicesGateways
{
    public class MirrorStateService : IMirrorStateServices
    {
        private VoiceUseCasesState _detectionState;
        private MirrorUser _currentMirrorUser;
        private readonly MirrorUser _defaultUser;

        public MirrorStateService()
        {
            var defaultSnow = new SnowUser("Default", "Default", "snowwhite@myyaps2gode", null);
            var defaultMirror = new MirrorUser(defaultSnow,true,false,null);
            this._detectionState = VoiceUseCasesState.UserDetection;
            this._defaultUser = defaultMirror;
        }

        public VoiceUseCasesState GetCurrentDetectionState()
        {
            return this._detectionState;
        }

        public void SetCurrentDetectionState(VoiceUseCasesState state)
        {
            this._detectionState = state;
        }

        public void SetCurrentUserTo(MirrorUser user)
        {
            this._currentMirrorUser = user;
        }

        public MirrorUser GetCurrentUser()
        {
            return _currentMirrorUser;
        }

        public MirrorUser LoadDefaultUser()
        {
            return _defaultUser;
        }
    }
}