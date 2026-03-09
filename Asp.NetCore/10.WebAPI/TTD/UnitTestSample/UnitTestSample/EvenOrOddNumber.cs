using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTestSample
{
    public class EvenOrOddNumber
    {
        public string ReturnsEvenOrOddNumber(int num)
        {
            if (num % 2 == 0)
            {
                return "Even Number";
            }
            else
            {
                return "Odd Number";
            }
        }
    }
}
