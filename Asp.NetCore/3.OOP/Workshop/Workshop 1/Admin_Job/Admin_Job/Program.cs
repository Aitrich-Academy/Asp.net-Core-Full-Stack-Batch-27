using Admin_Job.Manager;

class Program
{
    static void Main(string[] args)
    {
        Admin admin = new Admin();

        Console.WriteLine("Welcome to the job portal admin module!");

        while (true)
        {
            Console.WriteLine("Please select an option:");
            Console.WriteLine("1. Register");
            Console.WriteLine("2. Login");
            Console.WriteLine("3. Exit");

            string input = Console.ReadLine();

            switch (input)
            {
                case "1":
                    Console.Write("Enter username: ");
                    string regUsername = Console.ReadLine();

                    Console.Write("Enter password: ");
                    string regPassword = Console.ReadLine();

                    admin.Register(regUsername, regPassword);
                    break;

                case "2":
                    Console.Write("Enter username: ");
                    string loginUsername = Console.ReadLine();

                    Console.Write("Enter password: ");
                    string loginPassword = Console.ReadLine();

                    admin.Login(loginUsername, loginPassword);
                    break;

                case "3":
                    Console.WriteLine("Goodbye!");
                    return;

                default:
                    Console.WriteLine("Invalid option. Please try again.");
                    break;
            }
        }
    }
}