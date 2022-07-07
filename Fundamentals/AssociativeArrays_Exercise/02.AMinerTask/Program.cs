using System;
using System.Collections.Generic;

namespace _02.AMinerTask
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, int> resourseQuantity = new Dictionary<string, int>();

            while (true)
            {
                string resourceInput = Console.ReadLine();
                if (resourceInput == "stop") break;
                int quantityInput = int.Parse(Console.ReadLine());

                if (!resourseQuantity.ContainsKey(resourceInput))
                {
                    resourseQuantity.Add(resourceInput, quantityInput);
                }
                else
                {
                    resourseQuantity[resourceInput] += quantityInput;
                }
            }

            foreach (var resource in resourseQuantity)
            {
                Console.WriteLine($"{resource.Key} -> {resource.Value}");
            }
        }
    }
}
