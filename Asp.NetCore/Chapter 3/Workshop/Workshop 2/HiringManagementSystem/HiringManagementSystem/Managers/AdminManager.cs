using HiringManagementSystem.Models;
using HiringManagementSystem.Utils;
using HiringManagementSystem.Enums;
using HiringManagementSystem.Interface;

namespace HiringManagementSystem.Managers
{
    public class AdminManager : IMenu
    {
        private readonly User[] _users;
        private readonly int _userCount;
        private readonly JobManager _jobManager;   // Only use JobManager

        public AdminManager(User[] users, int userCount, JobManager jobManager)
        {
            _users = users;
            _userCount = userCount;
            _jobManager = jobManager;
        }

        public void DisplayMenu(object? publicManager = null)
        {
            var printer = new Printer();

            while (true)
            {
                Console.WriteLine("\n=== Admin Menu ===");
                Console.WriteLine("1. View Registrations");
                Console.WriteLine("2. Add Job");
                Console.WriteLine("3. List Jobs");
                Console.WriteLine("4. Logout");

                string? choice = Console.ReadLine();
                switch (choice)
                {
                    case "1":
                        printer.Print(_users);  //  Print users directly
                        break;

                    case "2":
                        AddJob();
                        break;

                    case "3":
                        printer.Print(_jobManager.GetJobs());  // Get jobs from JobManager
                        break;

                    case "4":
                        return;
                }
            }
        }

        private void AddJob()
        {
            Console.WriteLine("\n=== Add Job ===");
            Console.Write("Title: ");
            string title = Console.ReadLine() ?? "";
            Console.Write("Company: ");
            string company = Console.ReadLine() ?? "";
            Console.Write("Location: ");
            string location = Console.ReadLine() ?? "";
            Console.Write("Salary Range: ");
            string salary = Console.ReadLine() ?? "";
            Console.Write("Job Type: ");
            string jobType = Console.ReadLine() ?? "";

            Console.WriteLine("Select Experience Level: 1. Fresher  2. MidLevel  3. Senior");
            string choice = Console.ReadLine();
            ExperienceLevels exp;

            switch (choice)
            {
                case "2":
                    exp = ExperienceLevels.MidLevel;
                    break;
                case "3":
                    exp = ExperienceLevels.Senior;
                    break;
                default:
                    exp = ExperienceLevels.Fresher;
                    break;
            }

            Job job = new()
            {
                Title = title,
                Company = company,
                Location = location,
                SalaryRange = salary,
                JobType = jobType,
                ExperienceLevel = exp
            };

            _jobManager.AddJob(job);  // JobManager handles array + Id assignment
            Console.WriteLine("Job added successfully!");
        }
    }
}
