using System;
using System.Collections.Generic;
using System.Linq;

namespace _05.FashionBoutique
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] clothes = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();

            int rackCapacity = int.Parse(Console.ReadLine());
            int capacity = rackCapacity;
            Stack<int> stack = new Stack<int>(clothes);


            int counter = 1;

            while (stack.Count > 0)
            {
                if (rackCapacity - stack.Peek() < rackCapacity)
                {
                    rackCapacity -= stack.Pop();
                }

                if (stack.Count > 0)
                {
                    if (stack.Peek() > rackCapacity)
                    {
                        rackCapacity = capacity;
                        counter++;
                    }
                }
            }

            Console.WriteLine(counter);
        }
    }
}
