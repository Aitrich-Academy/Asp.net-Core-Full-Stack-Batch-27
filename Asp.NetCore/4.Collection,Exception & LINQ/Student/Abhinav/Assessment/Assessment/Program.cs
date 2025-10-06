using Assessment.Exception;
using Assessment.Models;

internal class Program
{
    private static void Main(string[] args)
    {
        CabService cabService = new CabService();

        while (true)
        {
            Console.WriteLine("Welcome to Cab Service\n" +
                "1.Add a cab\n" +
                "2.Remove a cab\n" +
                "3.Book a cab\n" +
                "4.Cancel a cab\n" +
                "5.Display all available cabs\n" +
                "6.Exit\n");

            Console.WriteLine("\nEnter your choice: ");
            string choice=Console.ReadLine();

            switch (choice)
            {
                case "1":
                    cabService.AddCab();
                    break;
                case "2":   
                    try
                    {
                        cabService.RemoveCab();
                    }
                    catch(CabNotExistException ex) 
                    {
                        Console.WriteLine(ex.Message);
                    }
                    break;
                case "3":
                    try
                    {
                        cabService.BookCab();
                    }
                    catch (CabNotExistException ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                    catch (CabNotAvailableException ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                    catch(AlreadyBookedException ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                    break;
                case "4":
                    try
                    {
                        cabService.CancelCab();
                    }
                    catch(CabNotExistException ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                    break;
                case "5":
                    cabService.DisplayCab();
                    break;
                case "6":
                    Console.WriteLine("\nExiting...");
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("\nInvalid Choice");
                    break;
            }
        }
    }
}