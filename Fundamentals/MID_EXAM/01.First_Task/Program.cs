using System;

namespace _01.First_Task
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberOfCities = int.Parse(Console.ReadLine());

            string cityName = String.Empty;
            float income = 0f;
            float expenses = 0f;
            float currentProfit = 0f;
            float totalProfit = 0f;

            for (int day = 1; day <= numberOfCities; day++)
            {
                bool isSpecialEventPossible = false;
                cityName = Console.ReadLine();
                income = float.Parse(Console.ReadLine());
                expenses = float.Parse(Console.ReadLine());
                
                if (day % 3 == 0 & day % 5 != 0)
                {
                    isSpecialEventPossible = true;
                }

                if (isSpecialEventPossible)
                {
                    currentProfit = income - (expenses+ (expenses / 2));
                }
                else
                {
                    currentProfit = income - expenses;
                }

                if (day % 5 == 0)
                {
                    currentProfit = income* 0.9f - expenses;
                }
                totalProfit += currentProfit;

                Console.WriteLine($"In {cityName} Burger Bus earned {currentProfit:f2} leva.");
            }

            Console.WriteLine($"Burger Bus total profit: {totalProfit:f2} leva.");
        }
    }
}
