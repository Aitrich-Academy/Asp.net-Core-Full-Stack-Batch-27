namespace InterfaceSample
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            Dog dog = new Dog();
            Cat cat = new Cat();

            dog.AnimalSound();
            dog.AnimalPrice();
            cat.AnimalSound();
            cat.AnimalPrice();
        }
    }
}
