using System.ComponentModel.DataAnnotations;
using LMS.Application.Common.Entities;

namespace LMS.Identity.API.Entities
{
    public class User : SqlEntity
    {
        public string FirstName { get; private set; } = string.Empty;
        public string LastName { get; private set; } = string.Empty; 
        public string Email { get; private set; } = string.Empty; 
        public string Password { get; private set; } = string.Empty;
        public string PhoneNumber { get; private set; } = string.Empty;
        public DateTime CreatedAt { get; private set; }
        public DateTime LastLogin { get; private set; }
		public Role Role { get; private set; } 


		public User(string firstName,string lastName,string email,string password, string phoneNumber, Role role)
        {
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            Password = password;
            CreatedAt = DateTime.UtcNow;
            PhoneNumber = phoneNumber;
            Role = role;
        }
        public void UpdateLastLogin() => LastLogin = DateTime.UtcNow;
        public void SetRole (Role role)
        {
            Role= role;
        }
    }
}
