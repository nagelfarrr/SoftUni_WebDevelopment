using System;
using System.Linq;

namespace _07.PredicateForNames
{
    internal class Program
    {
        static void Main(string[] args)
        {

            int nameLength = int.Parse(Console.ReadLine());
            string[] names = Console.ReadLine().Split();

            Predicate<string> len = str => str.Length <= nameLength;

            Console.WriteLine(string.Join(Environment.NewLine,names.Where(str=>len(str))));
        }
    }
}
