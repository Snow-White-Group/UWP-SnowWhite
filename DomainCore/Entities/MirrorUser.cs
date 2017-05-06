using System.Dynamic;

namespace Domain.Entities
{
    public class MirrorUser
    {
        public SnowUser SnowUser { get; set; }
        public bool IsDefaultUser { get; set; }
        public bool IsValidUser { get; set; }
        public string AnnonymousId { get; set; }

        public MirrorUser(SnowUser user, bool isDefaultUser, bool isValidUser, string anannonymousId)
        {
            this.SnowUser = user;
            this.IsDefaultUser = isDefaultUser;
            this.IsValidUser = isValidUser;
            this.AnnonymousId = anannonymousId;
        }
    }
}