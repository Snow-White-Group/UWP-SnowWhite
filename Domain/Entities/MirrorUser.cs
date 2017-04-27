using System.Dynamic;

namespace Domain.Entities
{
    public class MirrorUser
    {
        public SnowUser SnowUser { get; set; }
        public bool IsDefaultUser { get; set; }
        public bool IsValiedUser { get; set; }
        public string annonymousId { get; set; }

        public MirrorUser(SnowUser user, bool isDefaultUser, bool isValiedUser, string anannonymousId)
        {
            this.SnowUser = user;
            this.IsDefaultUser = isDefaultUser;
            this.IsValiedUser = isValiedUser;
            this.annonymousId = anannonymousId;
        }
    }
}