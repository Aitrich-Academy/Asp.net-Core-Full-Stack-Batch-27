using System;

namespace InterviewShedule
{
    internal class Program
    {
        struct Interview
        {
            public string Title;
            public DateTime Date;
            public string Time;
            public string Location;
        }

        static void Main(string[] args)
        {
            Interview[] schedule = new Interview[10];
            int interviewCount = 0; // Keep track of how many interviews are stored

            Console.WriteLine("\n-------------------------------------------------- Schedule An Interview For Job Seekers --------------------------------------------------\n");

            string choice;
            do
            {
                Console.WriteLine("A - Schedule an Interview");
                Console.WriteLine("D - Display Scheduled Interviews");
                Console.WriteLine("Select an option: ");
                string command = Console.ReadLine()?.Trim().ToUpper();

                switch (command)
                {
                    case "A":
                        Console.WriteLine("How many interviews do you want to schedule?");
                        int count = Convert.ToInt32(Console.ReadLine());

                        for (int i = 0; i < count && interviewCount < schedule.Length; i++)
                        {
                            Console.WriteLine($"\n---- Interview Schedule {interviewCount + 1} ----");
                            Console.Write("Enter the Job Title: ");
                            schedule[interviewCount].Title = Console.ReadLine();

                            Console.Write("Enter the Date (dd-mm-yyyy): ");
                            schedule[interviewCount].Date = DateTime.Parse(Console.ReadLine());

                            Console.Write("Enter the Time (hh:mm): ");
                            schedule[interviewCount].Time = Console.ReadLine();

                            Console.Write("Enter the Location: ");
                            schedule[interviewCount].Location = Console.ReadLine();

                            interviewCount++;
                        }
                        break;

                    case "D":
                        Console.WriteLine("\n--------------- Scheduled Interviews ---------------");

                        if (interviewCount == 0)
                        {
                            Console.WriteLine("No interviews scheduled yet.");
                        }
                        else
                        {
                            for (int i = 0; i < interviewCount; i++)
                            {
                                Console.WriteLine($"\nInterview ID: {i + 1}");
                                Console.WriteLine($"Job Title: {schedule[i].Title}");
                                Console.WriteLine($"Date: {schedule[i].Date:dd-MM-yyyy}");
                                Console.WriteLine($"Time: {schedule[i].Time}");
                                Console.WriteLine($"Location: {schedule[i].Location}");
                            }
                        }
                        break;

                    default:
                        Console.WriteLine("Invalid option! Please select A or D.");
                        break;
                }

                Console.WriteLine("\nDo you want to continue? (Y/N)");
                choice = Console.ReadLine()?.Trim().ToUpper();

            } while (choice == "Y");
        }
    }
}
