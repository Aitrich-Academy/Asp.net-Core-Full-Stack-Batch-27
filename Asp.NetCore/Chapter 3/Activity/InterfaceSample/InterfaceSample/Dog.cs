using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfaceSample
{
    internal class Dog : IAnimal,IPrice
    {
        public void AnimalSound()
        {
            Console.WriteLine("Dog is Barking...");
        }

        public void AnimalPrice()
        {
            Console.WriteLine("Price for Dog.....");
        }
    }
}
