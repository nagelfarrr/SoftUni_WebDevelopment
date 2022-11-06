namespace Animals
{
    using System;

    public class StartUp
    {
        static void Main(string[] args)
        {
            Animal cat = new Cat("Peter", "Gylyb");
            Animal dog = new Dog("Sara", "Kokal");

            Console.WriteLine(cat.ExplainSelf());
            Console.WriteLine(dog.ExplainSelf());
        }
    }
}
