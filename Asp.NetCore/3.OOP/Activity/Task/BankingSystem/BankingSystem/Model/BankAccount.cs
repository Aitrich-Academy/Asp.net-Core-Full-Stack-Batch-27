using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankingSystem.Model
{
    public class BankAccount
    {
        private decimal balance;  // Encapsulated field

        public int AccountNumber { get; private set; }
        public string AccountHolder { get; private set; }

        public BankAccount(int accountNumber, string accountHolder, decimal initialBalance)
        {
            AccountNumber = accountNumber;
            AccountHolder = accountHolder;
            balance = initialBalance;
        }

        // Encapsulation: Controlled access
        public decimal GetBalance()
        {
            return balance;
        }

        public void Deposit(decimal amount)
        {
            if (amount > 0)
                balance += amount;
        }

        public virtual void Withdraw(decimal amount)  // Virtual for polymorphism
        {
            if (amount > 0 && amount <= balance)
                balance -= amount;
        }
    }

}
