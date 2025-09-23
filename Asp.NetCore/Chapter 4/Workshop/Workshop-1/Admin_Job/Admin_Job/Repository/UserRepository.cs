using Admin_Job.Enums;
using Admin_Job.Interface;
using Admin_Job.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Admin_Job.Repository
{
    public sealed class UserRepository:IUserRepository
    {
        private List<User> users = new List<User> { new User(1, "admin", "", "admins@gmail.com", 123, "123", Roles.Admin), new User(2, "admin", "", "admin1@gmail.com", 123, "123", Roles.Admin), new User(3, "admin123", "", "admin@gmail.com", 123, "123", Roles.Admin) };
        private static User loggedUser;
        private int nextId = 2;
        public List<User> getAll()
        {
            return users.Where(e=>e.Role==Roles.Admin).ToList();
        }

        public User login(string email, string password)
        {
            loggedUser= users.FirstOrDefault(e=>e.Email==email&&e.Password==password);
            return loggedUser;
        }


        public User getLoggedUser()
            { return loggedUser; }



    }
}
