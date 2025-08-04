using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace PostJob
{
    internal class Program
    {
        struct Jobs
        {
            public string title;
            public string description;
            public double salary;
            public string Location;
        }
        public static void Main(string[] args)
        {
 
            Jobs[] jobs = new Jobs[10];

string choice;
          
            do
            {
                Console.WriteLine("------------------------------------------------------------------------------------------------------------------------------------------------------------------------\n");
                Console.WriteLine("------------------------------------------------------------------------------------Jobs Provider-----------------------------------------------------------------------\n");
                Console.WriteLine("A - Post a Job");
                Console.WriteLine("D - Display Posted Jobs");
                Console.WriteLine("Enter yes for Continue the process");
                Console.WriteLine("------------------------------------------------------------------------------------------------------------------------------------------------------------------------\n");
                Console.WriteLine("Please Select an Option");
                string Command = Console.ReadLine();
                switch (Command)
                {
                    case "A":
                        {
                            Console.WriteLine("How many No of Jobs You Want to post\n");
                            int Count = Convert.ToInt32(Console.ReadLine());
                            for (int i = 0; i < Count; i++)
                            {
                                Console.WriteLine("-----------------------------------------------------------------------------------------------------------------------------------------------------------------------\n");
                                Console.WriteLine("----------------------------------------------------------------JobDetails{0}---------------------------------------------------------------------------------------------\n", i + 1);
                                Console.WriteLine("------------------------------------------------------------------------------------------------------------------------------------------------------------------------\n");
                                Console.Write("Enter the Name of job {0}:\n ", i + 1);
                                jobs[i].title = Console.ReadLine();
                                Console.Write("Enter the description of job {0}:\n  ", i + 1);
                                jobs[i].description = Console.ReadLine();
                                Console.Write("Enter the salary of job {0}:\n  ", i + 1);
                                jobs[i].salary = Convert.ToDouble(Console.ReadLine());
                                Console.Write("Enter the Location of job {0}:\n  ", i + 1);
                                jobs[i].Location = Console.ReadLine();

                            }
                            break;
                        }
                    case "D":
                        {
                            Console.WriteLine("-----------------------------------------------------------------------------------------------------------------------------------------------------------------------\n");
                            Console.WriteLine("----------------------------------------List of Jobs-------------------------------------------------------------------------------------------------------------------\n");
                            Console.WriteLine("-----------------------------------------------------------------------------------------------------------------------------------------------------------------------\n");
                            for (int i = 0; i < jobs.Length; i++)
                            {
                                if (jobs[i].title != null)
                                {
                                    Console.WriteLine("------------------------------------------------------------------------------Job Id: {0}----------------------------------------------------------------------------------------\n", i + 1);
                                    Console.WriteLine("Name of Job: {0}", jobs[i].title);
                                    Console.WriteLine("description: {0}", jobs[i].description);
                                    Console.WriteLine("salary :{0}", jobs[i].salary);
                                    Console.WriteLine("Location:{0}", jobs[i].Location,"\n");
                                    Console.WriteLine("------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------\n");
                                }
                            }


                            Console.ReadLine();
                            break;
                        }
                }
                   



                
                Console.WriteLine("Do you want to continue (yes/No)\n");
                choice = Console.ReadLine();

            } while (choice == "yes");
        }
            } 
}
    