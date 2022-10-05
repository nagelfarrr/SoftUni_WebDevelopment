using System;
using System.Collections.Generic;
using System.Linq;

namespace _04.FindEvensOrOdds
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Predicate<int> isEven = n => n % 2 == 0;

            int[] range = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(n => int.Parse(n))
                .ToArray();

            string cmd = Console.ReadLine();

            List<int> numbers = new List<int>();

            for (int i = range[0]; i <= range[1]; i++)
            {
                numbers.Add(i);
            }


            if (cmd == "even")
            {
                numbers = numbers.Where(n => isEven(n)).ToList();
            }
            else
            {
                numbers = numbers.Where(n => !isEven(n)).ToList();
            }

            Console.WriteLine(string.Join(" ",numbers));
        }
    }
}
