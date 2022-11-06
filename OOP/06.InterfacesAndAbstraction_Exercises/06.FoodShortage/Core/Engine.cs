namespace _06.FoodShortage.Core
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using _06.FoodShortage.Models;
    using _06.FoodShortage.Models.Contracts;
    using Contracts;

    public class Engine : IEngine
    {
        public void Run()
        {
            int numberOfPeople = int.Parse(Console.ReadLine());

            List<IBuyer> buyers = new List<IBuyer>();

            for (int i = 0; i < numberOfPeople; i++)
            {
                string[] input = Console.ReadLine().Split();

                try
                {
                    if (input.Length == 4)
                    {
                        string name = input[0];
                        int age = int.Parse(input[1]);
                        string id = input[2];
                        string birthdate = input[3];

                        IBuyer citizen = new Citizen(name, age, id, birthdate);
                        buyers.Add(citizen);
                        
                    }
                    else if (input.Length == 3)
                    {
                        string name = input[0];
                        int age = int.Parse(input[1]);
                        string group = input[2];

                        IBuyer rebel = new Rebel(name, age, group);

                        buyers.Add(rebel);
                    }
                }

                catch (ArgumentException ae)
                {
                    Console.WriteLine(ae.Message);
                }
            }

            while (true)
            {
                string input = Console.ReadLine();
                if (input == "End") break;


                var currBuyer = buyers.FirstOrDefault(b => b.Name == input);
                
                if (currBuyer != null)
                {
                    currBuyer.BuyFood();
                }
            }

            Console.WriteLine(buyers.Sum(b=>b.Food));
        }
    }
}
