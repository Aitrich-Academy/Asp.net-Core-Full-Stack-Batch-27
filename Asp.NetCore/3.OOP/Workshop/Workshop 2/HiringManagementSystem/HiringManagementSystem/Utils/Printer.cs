using HiringManagementSystem.Models;

namespace HiringManagementSystem.Utils
{
    public class Printer
    {
        public void Print(Job[] jobs)
        {
            Console.WriteLine("\n=== Available Jobs ===");

            foreach (var job in jobs)
            {
                if (job == null) break; // stop when null is found in fixed array

                Console.WriteLine($"ID: {job.Id} | Title: {job.Title} | Company: {job.Company}");
                Console.WriteLine($"Location: {job.Location} | Salary: {job.SalaryRange} | Type: {job.JobType}");
                Console.WriteLine($"Experience: {job.ExperienceLevel}\n");
            }
        }

        public void Print(User[] users)
        {
            Console.WriteLine("\n=== Registered Users ===");

            foreach (var user in users)
            {
                if (user == null) break; // stop when null is found in fixed array

                Console.WriteLine($"ID: {user.Id} | Name: {user.FirstName} {user.LastName} | Role: {user.Role}");
                Console.WriteLine($"Email: {user.Email} | Phone: {user.Phone}\n");
            }
        }
    }

}
