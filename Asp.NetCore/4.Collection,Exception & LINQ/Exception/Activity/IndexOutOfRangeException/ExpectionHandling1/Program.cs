// See https://aka.ms/new-console-template for more information
using System;

namespace ExpectionHandling1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //IndexOutOfRangeException
            try
            {
                string[] pets = { "Dog", "Cat", "Parrot" };
                Console.WriteLine(pets[10]);
            }
            catch (IndexOutOfRangeException ex)
            {
                Console.WriteLine(ex.Message);
            }
            //finally
            //{
            //    Console.WriteLine("Final block executed");
            //}
        }
    }
}
