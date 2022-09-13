using System;
using System.Collections.Generic;
using System.Linq;

namespace _02.BasicQueueOperations
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //input
            int[] commandNumbers = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse).ToArray();

            int[] numbers = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse).ToArray();

            //declaration
            int elementsToPush = commandNumbers[0];
            int elementsToPop = commandNumbers[1];
            int numberToFind = commandNumbers[2];

            Queue<int> queue = new Queue<int>();

            Enqueue(queue, elementsToPush, numbers);

            Dequeue(queue, elementsToPop);

            if (queue.Contains(numberToFind))
                Console.WriteLine("true");
            else
            {
                if (queue.Count > 0)
                {
                    Console.WriteLine(queue.Min());
                }
                else
                {
                    Console.WriteLine(queue.Count);
                }
            }
        }
        static void Enqueue(Queue<int> queue, int elementsToPush, int[] numbers)
        {
            for (int i = 0; i < elementsToPush; i++)
            {
                queue.Enqueue(numbers[i]);
            }
        }

        static void Dequeue(Queue<int> queue, int elementsToPop)
        {
            for (int i = 0; i < elementsToPop; i++)
            {
                queue.Dequeue();
            }
        }
    }
}
