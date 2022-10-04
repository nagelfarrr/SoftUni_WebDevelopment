using System;
using System.Linq;
using System.Transactions;

namespace _04.AddVAT
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double[] prices = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .Select(n => double.Parse(n))
                .Select(n=> n*1.2)
                .ToArray();

            foreach (var price in prices)
            {
                Console.WriteLine($"{price:f2}");
            }
        }
    }
}
