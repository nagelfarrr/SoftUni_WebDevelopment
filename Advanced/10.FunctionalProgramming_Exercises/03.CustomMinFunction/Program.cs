using System;
using System.Linq;

namespace _03.CustomMinFunction
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(n => int.Parse(n))
                .ToArray();

            Func<int[], int> minNumber = (numbers) =>
            {
                int minNum = int.MaxValue;
                for (int i = 0; i < numbers.Length; i++)
                {
                    if (numbers[i] < minNum)
                    {
                        minNum = numbers[i];
                    }
                }


                return minNum;
            };

            Console.WriteLine($"{minNumber(numbers)}");
        }
    }
}
