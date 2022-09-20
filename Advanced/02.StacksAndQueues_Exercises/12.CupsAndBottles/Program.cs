using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace _12.CupsAndBottles
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] cups = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int[] bottles = Console.ReadLine().Split().Select(int.Parse).ToArray();

            int wastedLitters = 0;


            Stack<int> bottleStack = new Stack<int>(bottles);
            Queue<int> cupQueue = new Queue<int>(cups);

            while (true)
            {
                if (bottleStack.Count == 0 || cupQueue.Count == 0)
                    break;
                int currentBottle = bottleStack.Peek();
                int currentCup = cupQueue.Peek();

                while (currentCup > 0)
                {
                    if (currentBottle >= currentCup)
                    {
                        currentBottle--;
                        currentCup--;

                    }
                    else
                    {
                        currentCup -= currentBottle;
                        bottleStack.Pop();
                        currentBottle = bottleStack.Peek();
                    }
                }

                if (currentBottle >= currentCup)
                {
                    wastedLitters += currentBottle - currentCup;
                    cupQueue.Dequeue();
                    bottleStack.Pop();
                }
            }

            if (bottleStack.Count > 0)
            {
                Console.WriteLine($"Bottles: {string.Join(" ", bottleStack)}");
                Console.WriteLine($"Wasted litters of water: {wastedLitters}");
            }
            else if (cupQueue.Count > 0)
            {
                Console.WriteLine($"Cups: {string.Join(" ", cupQueue)}");
                Console.WriteLine($"Wasted litters of water: {wastedLitters}");
            }
        }
    }
}
