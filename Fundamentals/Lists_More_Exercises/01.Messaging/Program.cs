using System;
using System.Diagnostics.CodeAnalysis;
using System.Linq;

namespace _01.Messaging
{
    internal class Program
    {
        static void Main()
        {
            var numbers = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToList();

            var str = Console.ReadLine();

            var listNumber = 0;
            var stringIndex = 0;
            var result = String.Empty;

            for (var i = 0; i < numbers.Count; i++)
            {
                stringIndex = 0;
                var tempNum = 0;
                listNumber = numbers[i];
                while (listNumber > 0)
                {
                    tempNum = listNumber % 10;
                    stringIndex += tempNum;
                    listNumber /= 10;
                }

                if (stringIndex > str.Length)
                {

                    stringIndex = stringIndex - str.Length;

                }

                result += str[stringIndex];
                str = str.Remove(stringIndex, 1);
            }

            Console.WriteLine(result);
        }
    }
}