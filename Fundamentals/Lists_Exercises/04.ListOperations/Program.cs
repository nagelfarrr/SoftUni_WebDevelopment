using System;
using System.Collections.Generic;
using System.Linq;

namespace _04.ListOperations
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToList();

            string operations = String.Empty;

            while (operations != "End")
            {
                operations = Console.ReadLine();
                string[] tokens = operations.Split();

                switch (tokens[0])
                {
                    case "Add":
                        int numberToAdd = int.Parse(tokens[1]);
                        numbers.Add(numberToAdd);
                        break;
                    case "Insert":
                        int numberToInsert = int.Parse(tokens[1]);
                        int indexToInsert = int.Parse(tokens[2]);
                        if (indexToInsert > numbers.Count)
                        {
                            Console.WriteLine("Invalid index");
                        }
                        else
                            numbers.Insert(indexToInsert, numberToInsert);
                        break;
                    case "Remove":
                        int indexToRemove = int.Parse(tokens[1]);
                        if (indexToRemove > numbers.Count) Console.WriteLine("Invalid index");
                        else numbers.Remove(indexToRemove);
                        break;
                    case "Shift":
                        switch (tokens[1])
                        {
                            case "left":
                                int leftCountShifting = int.Parse(tokens[2]);
                                break;
                            case "right":
                                int rightCountShifting = int.Parse(tokens[2]);
                                break;
                        }
                        break;
                }
            }
        }
    }
}
