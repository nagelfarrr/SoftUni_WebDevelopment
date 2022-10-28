using System;

namespace Zoo
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            
            Lizard lizard = new Lizard("Ivan");
            Snake snake = new Snake("Petra");
            Animal animal = new Animal("Koko");

            Console.WriteLine(snake.Name);
            Console.WriteLine(lizard.Name);
            Console.WriteLine(animal.Name);
        }
    }
}