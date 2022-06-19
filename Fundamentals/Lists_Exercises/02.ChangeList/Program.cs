using System;
using System.Collections.Generic;
using System.Linq;

namespace _02.ChangeList
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToList();

            string input = String.Empty;

            while (input != "end")
            {
                input = Console.ReadLine();
                string[] tokens = input.Split();

                switch (tokens[0])
                {
                    case "Delete":
                        int elementToRemove = int.Parse(tokens[1]);
                        RemoveElement(numbers, elementToRemove);
                        break;
                    case "Insert":
                        int elementToInsert = int.Parse(tokens[1]);
                        int listIndex = int.Parse(tokens[2]);
                        InsertElement(numbers, elementToInsert, listIndex);
                        break;
                }
            }

            Console.WriteLine(string.Join(" ", numbers));
        }

        private static void InsertElement(List<int> numbers, int element, int listIndex)
        {
            numbers.Insert(listIndex,element);
        }

        static void RemoveElement(List<int> numbers, int element)
        {
            for (int i = 0; i < numbers.Count; i++)
            {
                if (numbers[i] == element)
                {
                    numbers.Remove(numbers[i]);
                }
            }
        }
    }
}
