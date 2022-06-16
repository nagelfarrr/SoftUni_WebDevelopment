using System;
using System.Collections.Generic;
using System.Linq;

namespace _02.GaussTrick
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToList();

            List<int> newList = new List<int>();
            int newValue = 0;
            for (int i = 0; i < numbers.Count/2; i++)
            {
                newValue = numbers[i] + numbers[numbers.Count - 1 - i];
                newList.Add(newValue);
            }

            if (numbers.Count % 2 != 0)
            {
                newList.Add(numbers[numbers.Count/2]);
            }

            Console.WriteLine(string.Join(" ", newList));
        }
    }
}
