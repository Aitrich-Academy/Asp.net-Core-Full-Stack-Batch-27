using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankingSystem.Model
{
    internal class CurrentAccount:BankAccount
    {
        private decimal overdraftLimit = 5000;

        public CurrentAccount(int accountNumber, string accountHolder, decimal initialBalance)
            : base(accountNumber, accountHolder, initialBalance) { }

        public override void Withdraw(decimal amount)
        {
            if (amount > 0 && amount <= GetBalance() + overdraftLimit)
            {
                base.Withdraw(amount);
            }
            else
            {
                Console.WriteLine("Overdraft limit exceeded in Current Account!");
            }
        }
    }
}
