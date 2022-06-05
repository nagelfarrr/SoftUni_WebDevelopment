using System;

namespace _02.PrintNumbersInReverseOrder
{
    class Program
    {
        static void Main(string[] args)
        {
            int input = int.Parse(Console.ReadLine());
            int[] numbersArray = new int[input];

            for (int i = 0; i < input; i++)
            {
                int number = int.Parse(Console.ReadLine());

                numbersArray[i] = number;
            }

            for (int i = numbersArray.Length -1; i >= 0; i--)
            {
                Console.Write($"{numbersArray[i]} ");
            }
        }
    }
}
