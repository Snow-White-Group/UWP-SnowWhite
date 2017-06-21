using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class MirrorAction
    {
        public UserForAction User { get; set; }
        public MirrorForAction TargetMirror { get; set; }
        public Action TargetAction { get; set; }

    }

    public class UserForAction
    {
        public string SnowId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
    }

    public class MirrorForAction
    {
        public string MirrorId { get; set; }
        public string DisplayName { get; set; }
        public string SecretName { get; set; }
    }

    public enum Action
    {
        Record,
        Handshake
    }
}
