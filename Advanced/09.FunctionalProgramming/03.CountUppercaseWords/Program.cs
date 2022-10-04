using System;
using System.Linq;

namespace _03.CountUppercaseWords
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Func<string, bool> isUpperFunc = str =>
                str.Split(" ", StringSplitOptions.RemoveEmptyEntries).All(str => char.IsUpper(str[0]));

            string[] text = Console.ReadLine()
                .Split(" ")
                .Where(w => isUpperFunc(w))
                .ToArray();

            Console.WriteLine(string.Join(Environment.NewLine,text));
        }
    }
}
