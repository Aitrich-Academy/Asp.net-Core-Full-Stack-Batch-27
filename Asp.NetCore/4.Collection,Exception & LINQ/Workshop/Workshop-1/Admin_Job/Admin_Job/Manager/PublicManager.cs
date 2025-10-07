using Admin_Job.Enums;
using Admin_Job.Exceptions;
using Admin_Job.Interface;
using Admin_Job.Models;
using Admin_Job.Repository;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Admin_Job.Manager
{
    public class PublicManager:IMenu
    {
        UserRepository userRepository=new UserRepository();
        public User LoggedUser=new User();
        bool _isLogged = false;
        IMenu menu;
        public void DisplayMenu()
        {
            showUserMenu();
        }
        public void showUserMenu()
        {
            bool exitProgram = false;
            while (!exitProgram)
            {
                Console.WriteLine("1.Login\n2.Exit\n");
                string option1 = Console.ReadLine();
                switch (option1)
                {
                    case "1":
                        LoginAdmin();
                        if (_isLogged)
                            menu.DisplayMenu();
                        break;
                    case "2":
                        exitProgram = true; break;
                    default:
                        Console.WriteLine("Invalid option");
                        break;
                }
            }

            }
         void LoginAdmin()
        {
            try
            {
                string email = GetEmail();
                Console.WriteLine("Please enter password");
                string password=Console.ReadLine();
                LoggedUser=userRepository.login(email,password); 
                if(LoggedUser!=null)
                {
                    Console.WriteLine("LoginSuccessful!!");
                    _isLogged = true;
                    Console.WriteLine("Welcome " + LoggedUser.FirstName);
                    if (LoggedUser.Role == Roles.Admin)
                        menu = new AdminManager(LoggedUser);
                    else
                        Console.WriteLine("Login failed");
                }

            }
            catch(Exception ex) { Console.WriteLine(ex.Message); }

        }
        private string GetEmail()
        {
            try
            {
                Console.WriteLine("Please enter your Email");
                string email = Console.ReadLine();
                Regex regex = new Regex(@"^[^@\s]+@[^@\s]+\.[^@\s]+$");
                if (!regex.IsMatch(email))
                    throw new InvalidFormatException("Please enter a valid Email " + email);
                return email;

            }
            catch (InvalidFormatException ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine("Try Again....");
                return GetEmail();

            }

            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return GetEmail();
            }

        }
        private long GetPhoneNumber()
        {
            try
            {
                Console.WriteLine("Please enter phone  number");
                long phoneNumber = long.Parse(Console.ReadLine());
                return phoneNumber;
                            }
            catch(Exception e)
            {
                Console.WriteLine("Enter a valid phone number");
                return GetPhoneNumber();
            }
        }
       
    }
}
