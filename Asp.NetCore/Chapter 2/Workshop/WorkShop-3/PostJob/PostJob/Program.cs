using System;

namespace PostJob
{
    internal class Program
    {
        struct Job
        {
            public string Title;
            public string Description;
            public double Salary;
            public string Location;
        }

        public static void Main(string[] args)
        {
            Job[] jobs = new Job[10];
            int jobCount = 0; // Track how many jobs have been added

            string choice;
            do
            {
                Console.WriteLine("\n-------------------------------- JOB PROVIDER --------------------------------\n");
                Console.WriteLine("A - Post a Job");
                Console.WriteLine("D - Display Posted Jobs");
                Console.WriteLine("Please select an option:");
                string command = Console.ReadLine()?.Trim().ToUpper();

                switch (command)
                {
                    case "A":
                        Console.WriteLine("How many jobs do you want to post?");
                        int count = Convert.ToInt32(Console.ReadLine());

                        for (int i = 0; i < count && jobCount < jobs.Length; i++)
                        {
                            Console.WriteLine($"\n---- Job Details {jobCount + 1} ----");
                            Console.Write("Enter the name of job: ");
                            jobs[jobCount].Title = Console.ReadLine();

                            Console.Write("Enter the description of job: ");
                            jobs[jobCount].Description = Console.ReadLine();

                            Console.Write("Enter the salary of job: ");
                            jobs[jobCount].Salary = Convert.ToDouble(Console.ReadLine());

                            Console.Write("Enter the location of job: ");
                            jobs[jobCount].Location = Console.ReadLine();

                            jobCount++;
                        }
                        break;

                    case "D":
                        Console.WriteLine("\n------------------ List of Jobs ------------------");
                        if (jobCount == 0)
                        {
                            Console.WriteLine("No jobs posted yet.");
                        }
                        else
                        {
                            for (int i = 0; i < jobCount; i++)
                            {
                                Console.WriteLine($"\nJob ID: {i + 1}");
                                Console.WriteLine($"Name of Job: {jobs[i].Title}");
                                Console.WriteLine($"Description: {jobs[i].Description}");
                                Console.WriteLine($"Salary: {jobs[i].Salary}");
                                Console.WriteLine($"Location: {jobs[i].Location}");
                            }
                        }
                        break;

                    default:
                        Console.WriteLine("Invalid option! Please choose A or D.");
                        break;
                }

                Console.WriteLine("\nDo you want to continue? (yes/no)");
                choice = Console.ReadLine()?.Trim().ToLower();

            } while (choice == "yes");
        }
    }
}
