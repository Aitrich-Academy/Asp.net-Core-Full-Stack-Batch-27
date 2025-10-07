using BankingSystem.Model;

internal class Program
{
    private static void Main(string[] args)
    {
        BankAccount acc1 = new SavingsAccount(101, "Alice", 5000);
        BankAccount acc2 = new CurrentAccount(102, "Bob", 2000);
        LoanAccount loan = new HomeLoan(103, "Charlie", 100000);

        acc1.Withdraw(6000); // Savings account limit check
        acc2.Withdraw(6000); // Current account allows overdraft

        Console.WriteLine($"Alice Balance: {acc1.GetBalance()}");
        Console.WriteLine($"Bob Balance: {acc2.GetBalance()}");
        Console.WriteLine($"Charlie Loan Interest: {loan.CalculateInterest()}");
    }
}