using System;

namespace _06.MiddleCharacters
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            PrintMiddleChar(input);

        }

        static void PrintMiddleChar(string input)
        {
            int len = input.Length;
            int middleChar = len / 2;

            if (len % 2 == 0)
            {
                Console.WriteLine($"{input[middleChar-1]}{input[middleChar]}");
            }
            else
            {
                Console.WriteLine(input[middleChar]);
            }
        }
    }
}
