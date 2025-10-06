using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfaceSample
{
    internal class Cat : IAnimal,IPrice
    {
        public void AnimalSound()
        {
            Console.WriteLine("Cat is Making sound Meow.....");
        }
        public void AnimalPrice()
        {
            Console.WriteLine("Price for Cat.....");
        }
    }
}
