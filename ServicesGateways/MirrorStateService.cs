using Domain.Entities;
using Domain.Services;

namespace ServicesGateways
{
    public class MirrorStateService : IMirrorStateServices
    {
        private MirrorUser _currentMirrorUser;
        private readonly MirrorUser _defaultUser;

        public MirrorStateService()
        {
            var defaultSnow = new SnowUser("Default", "Default", "snowwhite@myyaps2gode", null);
            var defaultMirror = new MirrorUser(defaultSnow,true,false,null);
            this._defaultUser = defaultMirror;
        }

        public void SetCurrentUserTO(MirrorUser user)
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