using System;
using System.Collections.Generic;
using System.Linq;

namespace _02.SetsOfElements
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] length = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(n => int.Parse(n)).ToArray();

            int firstSetCapacity = length[0];
            int secondSetCapacity = length[1];

            HashSet<int> firstSet = new HashSet<int>();
            HashSet<int> secondSet = new HashSet<int>();

            for (int i = 0; i < firstSetCapacity; i++)
            {

                int input = int.Parse(Console.ReadLine());
                firstSet.Add(input);
            }

            for (int i = 0; i < secondSetCapacity; i++)
            {
                int input = int.Parse(Console.ReadLine());
                secondSet.Add(input);
            }


            firstSet.IntersectWith(secondSet);

            Console.WriteLine(string.Join(" ", firstSet));



        }

        
    }
}

