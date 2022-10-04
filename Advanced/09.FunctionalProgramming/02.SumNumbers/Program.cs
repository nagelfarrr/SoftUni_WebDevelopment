using System;
using System.Linq;

namespace _02.SumNumbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            Func<string, int> parser = n => int.Parse(n);

            int[] numbers = input
                .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .Select(parser)
                .ToArray();

            Console.WriteLine(string.Join(Environment.NewLine,numbers.Length,numbers.Sum()));
        }
    }
}
