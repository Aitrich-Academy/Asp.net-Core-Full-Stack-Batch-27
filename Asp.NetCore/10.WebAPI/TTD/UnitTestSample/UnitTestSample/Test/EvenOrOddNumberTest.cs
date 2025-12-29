using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTestSample.Test
{
    public class EvenOrOddNumberTest
    {
        //Naming Convention - ClassName_MethodName_ExpectedResult
        public static void EvenOrOddNumber_ReturnsEvenOrOddNumber_ReturnEvenNumber()
        {
            try
            {
                //Arrange - Go get your variables, whatever you need your classes, get functions
                int num = 8;
                EvenOrOddNumber evenOrOddNumber = new EvenOrOddNumber();

                //Act - Executes the function
                string result = evenOrOddNumber.ReturnsEvenOrOddNumber(num);

                //Assert - Whatever is returned is it what you want
                if (result == "Even Number")
                {
                    Console.WriteLine("Passed");
                }
                else
                {
                    Console.WriteLine("Failed");
                }
            }
            catch (Exception ex) 
            {
                Console.WriteLine(ex);
            }
        }
    }
}

