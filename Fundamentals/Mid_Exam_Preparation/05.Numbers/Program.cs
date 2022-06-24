using System;
using System.Collections.Generic;
using System.Linq;

namespace _05.Numbers
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
            double average = numbers.Average();

            foreach (var number in numbers)
            {
                if (number > average)
                {
                    
                        newList.Add(number);
                }

            }

            newList.Sort();
            newList.Reverse();
            
            if (newList.Count == 0)
            {
                Console.WriteLine("No");
                return;
            }

            for (int i = 0; i < newList.Count; i++)
            {
                if (i == 5)
                {
                    break;
                }

                Console.Write(newList[i] + " ");
            }


        }
    }
}
