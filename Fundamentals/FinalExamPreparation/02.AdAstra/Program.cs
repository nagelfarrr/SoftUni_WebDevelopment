using System;
using System.Collections.Generic;
using System.Linq;

namespace _02.AdAstra
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            char[] splitOptions = new char[] { '|', '#' };

            List<Food> foodList = new List<Food>();
            string[] foodInfo = input.Split(splitOptions);
            Food food = new Food();
            for (int i = 0; i < foodInfo.Length; i++)
            {
                if (foodInfo[i].Any(char.IsLetterOrDigit) || foodInfo[i].Any(char.IsWhiteSpace))
                {
                    food = new Food()
                    {
                        itemName = foodInfo[i]
                    };
                }
                else if (!(foodInfo[i].Any(char.IsLetterOrDigit) || foodInfo[i].Any(char.IsWhiteSpace)))
                {
                    food = new Food()
                    {
                        expirationDate = foodInfo[i]
                    };
                }
                else if (foodInfo[i].All(char.IsDigit))
                {
                    food = new Food()
                    {
                        calories = int.Parse(foodInfo[i])
                    };
                }
                foodList.Add(food);
            }

        }
    }

    class Food
    {
        public string itemName { get; set; }
        public string expirationDate { get; set; }
        public int calories { get; set; }
    }
}
