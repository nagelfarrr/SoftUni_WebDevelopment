using System;
using System.Collections.Generic;
using System.Linq;

namespace _06.ReverseAndExclude
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(n => int.Parse(n))
                .ToList();

            int divNum = int.Parse(Console.ReadLine());

            Predicate<int> exclude = n => n % divNum != 0;

            Func<List<int>, List<int>> reverse = numbers =>
            {
                List<int> reversedList = new List<int>();
                for (int i = numbers.Count-1; i>=0; i--)
                {
                    reversedList.Add(numbers[i]);
                }

                return reversedList;
            };

            List<int> result = reverse(numbers).Where(n=>exclude(n)).ToList();

            Console.WriteLine(string.Join(" ",result));
        }
    }
}
