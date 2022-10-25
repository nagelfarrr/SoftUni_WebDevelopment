using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;

namespace MealPlan
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, int> mealsCalories = new Dictionary<string, int>()
            {
                { "salad", 350 },
                { "soup", 490 },
                { "pasta", 680 },
                { "steak", 790 },
            };

            Queue<string> meals =
                new Queue<string>(Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries));

            Stack<int> calories = new Stack<int>(Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(n => int.Parse(n)));

            int mealCounter = 0;

            while (meals.Any() && calories.Any() && calories.Peek() > 0)
            {
                int caloriesForToday = calories.Pop();
                string currentMeal = meals.Dequeue();
                mealCounter++;
                int currentCalories = mealsCalories[currentMeal];
                caloriesForToday -= currentCalories;

                while (caloriesForToday <= 0)
                {
                    if (!calories.Any())
                        break;
                    caloriesForToday += calories.Pop();
                }
                calories.Push(caloriesForToday);


            }

            if (!meals.Any())
            {
                Console.WriteLine($"John had {mealCounter++} meals.");
                Console.WriteLine($"For the next few days, he can eat {string.Join(", ", calories)} calories.");
            }
            else
            {
                Console.WriteLine($"John ate enough, he had {mealCounter++} meals.");
                Console.WriteLine($"Meals left: {string.Join(", ", meals)}.");
            }
        }
    }
}
