using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterviewShedule
{
    internal class Program
    {
        struct interview
        {
            public string title;
            public DateTime date;
            public string time;
            public string Location;
        }
        static void Main(string[] args)
        {
            interview[] shedule = new interview[10];
            Console.WriteLine("-----------------------------------------------------------------------------------------------------------------------------------------------------------------------\n");
            Console.WriteLine("----------------------------------------------------------------Shedule An Interview For job Seekers------------------------------------------------------------------\n");
            Console.WriteLine("------------------------------------------------------------------------------------------------------------------------------------------------------------------------\n");

            string ch;

            do
            {


                Console.WriteLine("A - Shedule a interview \n");
                Console.WriteLine("D - sheduled interview List\n");

                Console.WriteLine("------------------------------------------------------------------------------------------------------------------------------------------------------------------------\n");

                Console.WriteLine("Select an option");
                string Command = Console.ReadLine();
                switch (Command)
                {
                    case "A":
                        {
                            Console.WriteLine("How many no of interviews are sheduling\n");
                            int count = Convert.ToInt32(Console.ReadLine());
                            for (int i = 0; i < count; i++)
                            {

                                Console.WriteLine("----------------------------------------------------------Interviw shedule{0}--------------------------------------------------------------------------------------------", i + 1);
                                Console.WriteLine("------------------------------------------------------------------------------------------------------------------------------------------------------------------------\n");
                                Console.Write("Enter the Name of job post {0}: ", i + 1);
                                shedule[i].title = Console.ReadLine();
                                Console.WriteLine("Enter the Date for Interview(dd-mm-yyyy)");
                                shedule[i].date = Convert.ToDateTime(Console.ReadLine());
                                Console.WriteLine("Enter the Time of a Interview(h-m)");
                                shedule[i].time = Console.ReadLine();
                                Console.Write("Location of sheduled InterView {0}: ", i + 1);
                                shedule[i].Location = Console.ReadLine();
                                Console.WriteLine("------------------------------------------------------------------------------------------------------------------------------------------------------------------------\n");

                            }
                            break;
                        }
                    case "D":
                        {

                            Console.WriteLine("----------------------------------------------------------Sheduled interview Details are are:---------------------------------------------------------------------------");
                            Console.WriteLine("------------------------------------------------------------------------------------------------------------------------------------------------------------------------\n");
                            for (int i = 0; i < shedule.Length; i++)
                            {
                                if (shedule[i].title != null)
                                {
                                    Console.WriteLine("------------------------------------------------------------------------------------------------------------------------------------------------------------------------\n");
                                    Console.WriteLine("Name: {0}", shedule[i].title);
                                    Console.WriteLine("Date: {0}", shedule[i].date.Date.ToString("MM/dd/yyyy"));
                                    Console.WriteLine("Time :{0}", shedule[i].time);
                                   Console.WriteLine("Location: {0}", shedule[i].Location);
                                    Console.WriteLine("------------------------------------------------------------------------------------------------------------------------------------------------------------------------\n");
                                }
                            }


                            Console.ReadLine();
                            break;
                        }
                }





                Console.WriteLine("Do you want to continue (Y/N)\n");
                ch = Console.ReadLine();

            } while (ch == "y"||ch=="Y");
        }

    }
    }

