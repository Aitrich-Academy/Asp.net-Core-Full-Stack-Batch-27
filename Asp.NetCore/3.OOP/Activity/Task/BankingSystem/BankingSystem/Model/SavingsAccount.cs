using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankingSystem.Model
{
    internal class SavingsAccount:BankAccount
    {
        public SavingsAccount(int accountNumber, string accountHolder, decimal initialBalance)
       : base(accountNumber, accountHolder, initialBalance) { }

        // Polymorphism: override Withdraw
        public override void Withdraw(decimal amount)
        {
            if (amount > 0 && amount <= GetBalance())
            {
                base.Withdraw(amount);
            }
            else
            {
                Console.WriteLine("Insufficient balance in Savings Account!");
            }
        }
    }
}

