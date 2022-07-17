using System;
using System.Linq;

namespace _05.DigitsLettersAndOthers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            char[] digits = input.Where(ch => char.IsDigit(ch)).ToArray();
            char[] letters = input.Where(ch => char.IsLetter(ch)).ToArray();
            char[] other = input.Where(ch => !char.IsLetterOrDigit(ch)).ToArray();

            Console.WriteLine(digits);
            Console.WriteLine(letters);
            Console.WriteLine(other);
        }
    }
}
