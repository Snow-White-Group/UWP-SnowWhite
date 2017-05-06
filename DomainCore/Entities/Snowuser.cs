using System;

namespace Domain.Entities
{
    public class SnowUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string SnowId { get; set; }

        public SnowUser(string firstName, string lastName, string email, string snowID)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Email = email;
            this.SnowId = snowID;
        }
    }
}