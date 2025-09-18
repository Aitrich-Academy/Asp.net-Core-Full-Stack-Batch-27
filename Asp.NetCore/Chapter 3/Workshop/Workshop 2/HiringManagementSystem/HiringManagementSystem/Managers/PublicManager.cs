using HiringManagementSystem.Models;
using HiringManagementSystem.Enums;
using HiringManagementSystem.Interface;

namespace HiringManagementSystem.Managers
{
    public class PublicManager : ILogin, IMenu
    {
        private User[] _users = new User[5];   // fixed size user array
        private int _userCount = 0;

        private readonly JobManager _jobManager;  // Use JobManager for all job operations

        public PublicManager(JobManager jobManager)
        {
            _jobManager = jobManager;
        }

        public bool Login(string email, string password)
        {
            for (int i = 0; i < _userCount; i++)
            {
                if (_users[i].Email == email && _users[i].Password == password)
                    return true;
            }
            return false;
        }

        public void Register(User user)
        {
            if (_userCount >= _users.Length)
            {
                Console.WriteLine("Registration limit reached!");
                return;
            }

            user.Id = _userCount + 1;
            _users[_userCount] = user;
            _userCount++;
            Console.WriteLine("\nRegistration successful!");
        }

        public void DisplayMenu(object? publicManager = null)
        {
            while (true)
            {
                Console.WriteLine("\n=== Welcome to Hiring Management System ===");
                Console.WriteLine("1. Login");
                Console.WriteLine("2. Register");
                Console.WriteLine("3. Exit");
                Console.Write("Choose an option: ");
                string? choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        Console.Write("Enter Email: ");
                        string email = Console.ReadLine() ?? "";
                        Console.Write("Enter Password: ");
                        string password = Console.ReadLine() ?? "";

                        if (Login(email, password))
                        {
                            var user = Array.Find(_users, u => u != null && u.Email == email)!;

                            if (user.Role == Roles.Admin)
                            {
                                // AdminManager now only needs users + JobManager
                                new AdminManager(_users, _userCount, _jobManager).DisplayMenu(this);
                            }
                            else
                            {
                                // UserManager also uses JobManager
                                new UserManager(_jobManager).DisplayMenu(this);
                            }
                        }
                        else
                        {
                            Console.WriteLine("Invalid credentials!");
                        }
                        break;

                    case "2":
                        Console.WriteLine("\n=== Register User ===");
                        Console.Write("First Name: ");
                        string firstName = Console.ReadLine() ?? "";
                        Console.Write("Last Name: ");
                        string lastName = Console.ReadLine() ?? "";
                        Console.Write("Email: ");
                        string userEmail = Console.ReadLine() ?? "";
                        Console.Write("Phone: ");
                        string phone = Console.ReadLine() ?? "";
                        Console.Write("Password: ");
                        string userPassword = Console.ReadLine() ?? "";

                        Console.WriteLine("Select Role: 1. Admin  2. JobSeeker");
                        Roles role = (Console.ReadLine() == "1") ? Roles.Admin : Roles.JobSeeker;

                        User newUser = new()
                        {
                            FirstName = firstName,
                            LastName = lastName,
                            Email = userEmail,
                            Phone = phone,
                            Password = userPassword,
                            Role = role
                        };
                        Register(newUser);
                        break;

                    case "3":
                        return;
                }
            }
        }
    }
}
