using Admin_Job.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Admin_Job.Models
{
    public class User
    {
        public int Id { get; set; }
        public string? FirstName { get; set; }
        public string? LastName {  get; set; }
        public string Email { get; set; }
        public long Phone {  get; set; }
        public Roles Role { get; set; }
        public string Password { get; set; }
        public User() { }
        public User(int id,string firstname,string lastname,string email, long phone,string password, Roles roles)
        {
            Id = id;
            FirstName = firstname;
            LastName = lastname;
            Email = email;
            Phone = phone;
            Password = password;    
            Role = roles;

        }

    }
}
