using System;
using System.Linq;

namespace _05.TopInteger
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] arr = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            for (int i = 0; i < arr.Length - 1; i++)
            {
                if (arr[i] > arr[i + 1])
                {
                    Console.Write($"{arr[i]} ");
                }
            }

            Console.Write(arr.Last());
        }
    }
}
