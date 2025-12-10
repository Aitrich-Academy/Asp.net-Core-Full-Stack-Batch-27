using HireMeNow.Enums;
using HireMeNow.Models;
using System.ComponentModel.DataAnnotations;

namespace HireMeNow.Dto
{
   

public class UserDto
        {
            public Guid Id { get; set; }
            public string? FirstName { get; set; }
            public string? LastName { get; set; }
            
            [EmailAddress]
            public string? Email { get; set; } = null!;
            public string? Gender { get; set; }
            public string? Location { get; set; }
            public long? Phone { get; set; }
          
            public byte[]? Image { get; set; }
            public string? Password { get; set; }

            
            public Roles? Role { get; set; }
            public string? About { get; set; }


            public string? Token { get; set; }
        public virtual ICollection<Experience> Experiences { get; set; } = new List<Experience>();
        public virtual ICollection<Qualification> Qualifications { get; set; } = new List<Qualification>();

        public virtual ICollection<Skill> Skills { get; set; } = new List<Skill>();

        public UserDto()
            {

            }
            public UserDto(string firstName, string lastName, string email, string gender, string? location, long phone, string password, Roles role)
            {
                FirstName = firstName;
                LastName = lastName;
                Email = email;
                Gender = gender;
                Location = location;
                Phone = phone;
                Password = password;
                Role = role;
            }
        }
    }


