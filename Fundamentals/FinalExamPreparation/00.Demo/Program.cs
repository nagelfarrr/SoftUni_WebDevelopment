using System;

namespace _00.Demo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double incomePerSearch = double.Parse(Console.ReadLine());
            int numberOfUsers = int.Parse(Console.ReadLine());

            double totalIncome = 0;
            for (int i = 1; i <= numberOfUsers; i++)
            {
                int numberOfSearches = int.Parse(Console.ReadLine());
                double totalIncomePerUser = incomePerSearch *numberOfSearches;
                if (numberOfSearches == 1)
                {
                    continue;
                }
                else
                {
                    if (i % 3 == 0)
                    {
                        totalIncomePerUser *=3;
                    }

                    if (numberOfSearches > 5)
                    {
                        totalIncomePerUser *=2;
                    }
                    
                }

                totalIncome += totalIncomePerUser;
            }

            Console.WriteLine($"Total money earned: {totalIncome:f2}");
        }
    }
}
