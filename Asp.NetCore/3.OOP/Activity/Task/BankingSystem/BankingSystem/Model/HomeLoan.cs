using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankingSystem.Model
{
    public class HomeLoan : LoanAccount
    {
        public HomeLoan(int accountNumber, string accountHolder, decimal initialBalance)
            : base(accountNumber, accountHolder, initialBalance) { }

        public override decimal CalculateInterest()
        {
            return GetBalance() * 0.07m; // 7% interest
        }
    }
}
