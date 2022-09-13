using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace _04.FastFood
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int foodQuantity = int.Parse(Console.ReadLine());

            int[] orders = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();

            Queue<int> queue = new Queue<int>(orders);

            Console.WriteLine(queue.Max());

            while (foodQuantity > 0)
            {
                if (queue.Count > 0)
                {
                    if (foodQuantity < queue.Peek())
                        break;

                    if (foodQuantity >= queue.Peek())
                    {
                        foodQuantity -= queue.Dequeue();
                    }
                }
                else
                    break;



            }

            if (queue.Count == 0)
            {
                Console.WriteLine("Orders complete");
            }
            else
            {
                Console.WriteLine($"Orders left: {string.Join(" ", queue)}");
            }
        }
    }
}
