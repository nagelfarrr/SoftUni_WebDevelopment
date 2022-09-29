using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace _03.Largest3Numbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(n => int.Parse(n)).ToList();

            numbers = numbers.OrderByDescending(n => n).ToList();

            for (int i = 0; i < 3; i++)
            {
                if (i > numbers.Count-1)
                    break;
                Console.Write($"{numbers[i]} ");
            }
        }
    }
}
