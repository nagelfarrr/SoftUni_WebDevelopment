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
            string currentMeal = meals.Peek();
            int currentCalories = mealsCalories[currentMeal];
            int caloriesForToday = calories.Peek();
            while (meals.Count != 0 && calories.Count != 0)
            {
                //starts to eat
                while (caloriesForToday > 0)
                {
                    if (calories.Count == 0 && meals.Count == 0)
                        break;

                    if (caloriesForToday > currentCalories)
                    {
                        caloriesForToday -= currentCalories;
                        meals.Dequeue();
                        mealCounter++;
                        currentCalories = 0;
                    }
                    else
                    {
                        calories.Pop();
                        if (currentCalories > caloriesForToday)
                        {
                            currentCalories -= caloriesForToday;
                        }
                    }

                    currentMeal = meals.Peek();
                    if (currentCalories == 0)
                        currentCalories = mealsCalories[currentMeal];
                    else
                    {
                        calories.Push(calories.Pop() - currentCalories);
                    }


                }



            }

            if (meals.Count == 0)
            {
                Console.WriteLine($"John had {mealCounter++} meals.");
                Console.WriteLine($"For the nex few days, he can eat {string.Join(", ", calories)} calories/");
            }
            else
            {
                Console.WriteLine($"John ate enough, he had {mealCounter++} meals.");
                Console.WriteLine($"Meals left: {string.Join(", ", meals)}");
            }
        }
    }
}
