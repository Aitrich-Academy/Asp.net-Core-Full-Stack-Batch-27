using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Services;
using System.Text;
using System.Threading.Tasks;

namespace AdminProfile
{
    internal class Program
    {
        struct adminProfile
        {
            public string fullname;
            public string username;
            public string Email;
            public long Phonenumber;
        }
        static void Main(string[] args)
        {
            adminProfile[] admin = new adminProfile[1];

             string ch;
            Console.WriteLine("-----------------------------------------------------------------------------------------------------------------------------------------------------------------------\n");
            Console.WriteLine("---------------------------------------------------------------- Welcome to Admin Part----------------------------------------------------------------------------------\n");
            Console.WriteLine("------------------------------------------------------------------------------------------------------------------------------------------------------------------------\n");

            do
            {
                Console.WriteLine("A - Register as Admin" );
                Console.WriteLine("D - Display Admin Details");
                Console.WriteLine("------------------------------------------------------------------------------------------------------------------------------------------------------------------------\n");
                Console.WriteLine("Select an option from the list\n");
                string Command = Console.ReadLine();
                switch (Command)
                {
                    case "A":
                        {


                            Console.WriteLine("----------------------------------------------------------------Admin Registration-------------------------------------------------------------------------------------\n");
                            Console.WriteLine("------------------------------------------------------------------------------------------------------------------------------------------------------------------------\n");
                            Console.Write("Enter name of Admin:  \n ");
                            admin[0].fullname = Console.ReadLine();
                                Console.Write("Enter the username of admin : \n ");
                            admin[0].username = Console.ReadLine();
                                Console.Write("Enter the Email of admin : \n");
                            admin[0].Email = Console.ReadLine();
                                Console.Write("Enter the Phone no of Admin : \n");
                            admin[0].Phonenumber = Convert.ToInt64(Console.ReadLine());
                            Console.WriteLine("------------------------------------------------------------------------------------------------------------------------------------------------------------------------\n");


                            break;
                        }

                    case "D":
                        {


                            Console.WriteLine("----------------------------------------------------------------List of Admin-------------------------------------------------------------------------------------\n");
                            Console.WriteLine("------------------------------------------------------------------------------------------------------------------------------------------------------------------------\n");
                            Console.WriteLine("Enter name of Admin :  {0}", admin[0].fullname,"\n");
                                    
                                    Console.WriteLine("Enter the username of admin :{0} ", admin[0].username,"\n");
                                    Console.WriteLine("Enter the Email of Admin :{0} ", admin[0].Email,"\n");
                                    Console.WriteLine("Enter the Phone no of Admin : {0}", admin[0].Phonenumber,"\n");
                                    
                               
                            
                            break;
                        }

                }
                Console.WriteLine("Do you want to continue (Y/N)");
                ch = Console.ReadLine();
            }
            while (ch == "Y"||ch=="y");

        }
    }
}
