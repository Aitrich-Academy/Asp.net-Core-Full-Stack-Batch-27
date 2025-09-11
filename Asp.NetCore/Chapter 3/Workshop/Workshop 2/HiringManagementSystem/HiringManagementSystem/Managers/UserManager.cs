using HiringManagementSystem.Models;
using HiringManagementSystem.Utils;
using HiringManagementSystem.Interface;

namespace HiringManagementSystem.Managers
{
    public class UserManager : IMenu
    {
        private readonly JobManager _jobManager;  //  JobManager reference

        public UserManager(JobManager jobManager)
        {
            _jobManager = jobManager;
        }

        public void DisplayMenu(object? publicManager = null)
        {
            var printer = new Printer();
            while (true)
            {
                Console.WriteLine("\n=== JobSeeker Menu ===");
                Console.WriteLine("1. View Jobs");
                Console.WriteLine("2. Logout");

                string? choice = Console.ReadLine();
                switch (choice)
                {
                    case "1":
                        // Get jobs from JobManager
                        var jobs = _jobManager.GetJobs();
                        printer.Print(jobs);
                        break;
                    case "2":
                        return;
                }
            }
        }
    }
}
