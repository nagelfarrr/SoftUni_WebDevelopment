using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace _05.PrintEvenNumbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] arr = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();

            Queue<int> evenQueue = new Queue<int>();

            foreach (var num in arr)
            {
                if(num%2 ==0)
                    evenQueue.Enqueue(num);
            }

            Console.WriteLine(string.Join(", ", evenQueue));
        }
    }
}
