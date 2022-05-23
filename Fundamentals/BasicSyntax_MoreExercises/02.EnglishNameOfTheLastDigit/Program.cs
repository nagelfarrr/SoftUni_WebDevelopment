using System;

namespace _02.EnglishNameOfTheLastDigit
{
    class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());

            string[] spelling = { "zero", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine", };

            int lastDigit = number % 10;

            Console.WriteLine(spelling[lastDigit]);



        }
    }
}
