using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;

namespace BaristaContest
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, int> drinks = new Dictionary<string, int>()
            {
                { "Cortado", 50 },
                { "Espresso", 75 },
                { "Capuccino", 100 },
                { "Americano", 150 },
                { "Latte", 200 },
            };



            int[] coffeeQuantity = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .Select(n => int.Parse(n)).ToArray();

            int[] milkQuantity = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .Select(n => int.Parse(n)).ToArray();

            Queue<int> coffee = new Queue<int>(coffeeQuantity);
            Stack<int> milk = new Stack<int>(milkQuantity);

            Dictionary<string, int> brewedDrinks = new Dictionary<string, int>();

            bool isDrinkMade = false;
            while (true)
            {
                if (coffee.Count ==0 || milk.Count == 0)
                    break;

                isDrinkMade = false;
                int coffeMilkSum = coffee.Peek() + milk.Peek();


                foreach (var drink in drinks)
                {
                    if (drink.Value == coffeMilkSum)
                    {
                        if (!brewedDrinks.ContainsKey(drink.Key))
                        {
                            brewedDrinks.Add(drink.Key, 1);
                        }
                        else
                        {
                            brewedDrinks[drink.Key]++;

                        }

                        coffee.Dequeue();
                        milk.Pop();
                        isDrinkMade = true;
                        break;
                    }
                }

                if (!isDrinkMade)
                {
                    if (coffee.Any())
                    {
                        coffee.Dequeue();
                    }

                    if (milk.Any())
                    {
                        milk.Push(milk.Pop() - 5);
                    }
                }
            }



            
            string firstLine;

            if (coffee.Count == 0 && milk.Count == 0)
                firstLine = "Nina is going to win! She used all the coffee and milk!";
            else
                firstLine = "Nina needs to exercise more! She didn't use all the coffee and milk!";

            Console.WriteLine(firstLine);
            
            string coffeeLeft;

            if (coffee.Count == 0)
                coffeeLeft = "none";
            else
                coffeeLeft = String.Join(", ", coffee);

            Console.WriteLine($"Coffee left: {coffeeLeft}");
            
            string milkLeft;

            if (milk.Count == 0)
                milkLeft = "none";
            else
                milkLeft = String.Join(", ", milk);

            Console.WriteLine($"Milk left: {milkLeft}");

           
            foreach (var drink in brewedDrinks.OrderBy(x => x.Value).ThenByDescending(x => x.Key))
            {
                Console.WriteLine($"{drink.Key}: {drink.Value}");
            }

        }
    }
}
