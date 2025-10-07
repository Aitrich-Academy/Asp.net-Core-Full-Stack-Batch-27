using Admin_Job.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Admin_Job.Manager
{
    internal class Admin
    {
        private User[] users = new User[2];
        private int num_users = 0;
        JobManager job = new JobManager();
        bool _isLogged = false;
        public void Register(string username, string password)
        {
            if (num_users == users.Length)
            {
                Console.WriteLine("Maximum number of users reached. Please try again later.");
                return;
            }

            // Check if username is already taken
            

            User newUser = new User(username, password);
            users[num_users] = newUser;
            num_users++;

            Console.WriteLine("Registration successful.");
        }

        public bool Login(string username, string password)
        {
            for (int i = 0; i < num_users; i++)
            {
                if (users[i].Username == username && users[i].Password == password)
                {
                    Console.WriteLine("Login successful!");
                    _isLogged = true;
                    string ch = "0";
                    if (_isLogged)

                        while (ch != "3")
                        {
                            Console.WriteLine("1 .post job\n");
                            Console.WriteLine("2.List job\n");
                            Console.WriteLine("3.Back to main menu\n");
                            ch = Console.ReadLine();

                            if (ch == "1")
                            {
                                job.addjob();

                            }
                            if (ch == "2")
                            {
                                job.ListJob();
                            }
                            if (ch == "3")
                            {
                                Console.Write("exit");
                            }
                        }
                            return true;
                        }
                }

                Console.WriteLine("Invalid username or password.");
                return false;
            }


        }
    }

