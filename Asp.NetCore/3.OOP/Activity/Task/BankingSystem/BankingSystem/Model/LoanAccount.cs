using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankingSystem.Model
{
    public abstract class LoanAccount : BankAccount
    {
        public LoanAccount(int accountNumber, string accountHolder, decimal initialBalance)
            : base(accountNumber, accountHolder, initialBalance) { }

        public abstract decimal CalculateInterest();
    }

}
