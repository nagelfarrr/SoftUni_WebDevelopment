using System;
using System.Collections.Generic;

namespace _07.HotPotato
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split(' ');
            int hotPotato = int.Parse(Console.ReadLine());

            Queue<string> kidsQueue = new Queue<string>(input);

            for (int i = kidsQueue.Count; i > 1; i--)
            {
                int turns = hotPotato;
                while (turns > 1)
                {
                    kidsQueue.Enqueue(kidsQueue.Dequeue());

                    turns--;
                }

                Console.WriteLine($"Removed {kidsQueue.Dequeue()}");
            }

            Console.WriteLine($"Last is {kidsQueue.Peek()}");
        }
    }
}
