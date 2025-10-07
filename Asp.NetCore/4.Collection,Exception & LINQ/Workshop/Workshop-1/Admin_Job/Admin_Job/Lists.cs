using Admin_Job.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Admin_Job
{
    public class Lists
    {
        public void Print(List<User> Admins)
        {
            Console.WriteLine("Registraions:\n");
            Console.WriteLine("{0,-10}|{1,-20}|{2,-20}|{3,-20}|{4,-20} ", "Id", "First Name", "Last Name", "Phone", "Email");
            if (Admins != null)
        
                foreach (User item in Admins)
                {
                    Console.WriteLine("-----------------------------------------------------------------------------------------------------------");
                    Console.WriteLine("{0,-10}|{1,-20}|{2,-20}|{3,-20}|{4,-20} ", item.Id, item.FirstName, item.LastName, item.Phone, item.Email);
                }
                Console.WriteLine("\n");
            } 
        
            public void Print(List<Job> jobs)
        {
            Console.WriteLine("Jobs:\n");
            Console.WriteLine("{0,-10}|{1,-20}|{2,-20}|{3,-20}|{4,-20}|{5,-20}|{6,-20}", "JobId", "Title", "Description", "Company", "Location", "Salary Range", "Job Type");
            if(jobs != null)
                foreach (Job job in jobs)
                {
                    Console.WriteLine("-----------------------------------------------------------------------------------------------------------------------------");
                    Console.WriteLine("{0,10}|{1,-20}|{2,-20}|{3,-20}|{4,-20}|{5,-20}|{6,-20}", job.Id, job.Title, job.Description, job.Company, job.Location, job.Salary, job.Type);
                }
            Console.WriteLine("\n");
        }

        }
    }

