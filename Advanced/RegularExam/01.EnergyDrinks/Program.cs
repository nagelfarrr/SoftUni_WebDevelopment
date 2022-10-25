using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace _01.EnergyDrinks
{
    internal class Program
    {
        static void Main(string[] args)
        {
           
            int caffeineConsumed = 0;
            int maxCaffeine = 300;
            Stack<int> caffeine = new Stack<int>(Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries).Select(n => int.Parse(n)));
            Queue<int> energyDrink = new Queue<int>(Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .Select(n => int.Parse(n)));

            while (true)
            {
                if (!caffeine.Any()) break;
                if (!energyDrink.Any()) break;
                if (caffeineConsumed > maxCaffeine) break;
                int sumOfCaffeine = caffeine.Peek() * energyDrink.Peek();


                if (sumOfCaffeine + caffeineConsumed <= maxCaffeine)
                {
                    caffeine.Pop();
                    energyDrink.Dequeue();
                    caffeineConsumed += sumOfCaffeine;
                }
                else
                {
                    caffeine.Pop();
                    energyDrink.Enqueue(energyDrink.Dequeue());

                    if (caffeineConsumed - 30 <= 0) continue;
                    caffeineConsumed -= 30;
                   
                }
                
                
            }

            if (energyDrink.Any())
            {
                Console.WriteLine($"Drinks left: {string.Join(", ", energyDrink)}");
            }
            else
            {
                Console.WriteLine($"At least Stamat wasn't exceeding the maximum caffeine.");
            }

            Console.WriteLine($"Stamat is going to sleep with {caffeineConsumed} mg caffeine.");
        }
    }
}
