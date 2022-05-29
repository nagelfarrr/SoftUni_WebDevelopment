using System;

namespace _04.SumOfChars
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberOfLines = int.Parse(Console.ReadLine());

            int totalSum = 0;

            for (int i = 0; i < numberOfLines; i++)
            {
                char letter = char.Parse(Console.ReadLine());
                //int charValue = (int)letter;
                totalSum += (int)letter;

            }

            Console.WriteLine($"The sum equals: {totalSum}");
        }
    }
}
