using System;

namespace _07.PredicateForNames
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Predicate<string> length = (str, num) =>
            {
                str.Length <= num;
            };

            int nameLength = int.Parse(Console.ReadLine());
            string[] names = Console.ReadLine().Split();
        }
    }
}
