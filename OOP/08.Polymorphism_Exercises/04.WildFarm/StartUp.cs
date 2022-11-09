namespace WildFarm
{
    using System;
    using System.Collections.Generic;

    using Models;

    public class StartUp
    {
        static void Main(string[] args)
        {
            HashSet<Animal> animals = new HashSet<Animal>();

            while (true)
            {
                string input = Console.ReadLine();
                if (input == "End") break;

                Animal animal = Factory.GetAnimal(input);
                Console.WriteLine(animal.ProduceSound());

                Food food = Factory.GetFood(Console.ReadLine());

                animal.Eat(food);
                animals.Add(animal);
            }


            foreach (var animal in animals)
            {
                Console.WriteLine(animal);
            }
        }
    }
}
