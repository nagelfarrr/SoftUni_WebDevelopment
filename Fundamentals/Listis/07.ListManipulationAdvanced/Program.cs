using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace _07.ListManipulationAdvanced
{
    class Program
    {
        static void Main(string[] args)
        {

            List<int> numbers = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToList();

            while (true)
            {
                string input = Console.ReadLine();
                if (input == "end") break;

                string[] tokens = input.Split();
                string action = tokens[0];
                switch (action)
                {
                    case "Add":
                        int numberToAdd = int.Parse(tokens[1]);
                        numbers.Add(numberToAdd);
                        Console.WriteLine(string.Join(" ", numbers));
                        break;
                    case "Remove":
                        int numberToRemove = int.Parse(tokens[1]);
                        numbers.Remove(numberToRemove);
                        Console.WriteLine(string.Join(" ", numbers));
                        break;
                    case "RemoveAt":
                        int indexToRemove = int.Parse(tokens[1]);
                        numbers.RemoveAt(indexToRemove);
                        Console.WriteLine(string.Join(" ", numbers));
                        break;
                    case "Insert":
                        int numberToInsert = int.Parse(tokens[1]);
                        int indexToInsert = int.Parse(tokens[2]);
                        numbers.Insert(indexToInsert, numberToInsert);
                        Console.WriteLine(string.Join(" ", numbers));
                        break;
                    case "Contains":
                        int containedNumber = int.Parse(tokens[1]);
                        if (numbers.Contains(containedNumber))
                        {
                            Console.WriteLine("Yes");
                        }
                        else
                        {
                            Console.WriteLine("No such number");
                        }
                        break;
                    case "PrintEven":
                        List<int> evenList = new List<int>();
                        foreach (var evenValue in numbers)
                        {
                            if (evenValue % 2 == 0)
                            {
                                evenList.Add(evenValue);
                            }
                        }

                        Console.WriteLine(string.Join(" ",evenList));
                        break;
                    case "PrintOdd":
                        List<int> oddList = new List<int>();
                        foreach (var oddValue in numbers)
                        {
                            if (oddValue % 2 != 0)
                            {
                                oddList.Add(oddValue);
                            }
                        }
                        Console.WriteLine(string.Join(" ", oddList));
                        break;
                    case "GetSum":
                        int sum = 0;
                        foreach (var value in numbers)
                        {
                            sum += value;
                        }
                        Console.WriteLine(sum);
                        break;

                    case "Filter":
                        int number = int.Parse(tokens[2]);
                        List<int> newList = new List<int>();
                        switch (tokens[1])
                        {
                            case "<":
                                for (int i = 0; i < numbers.Count; i++)
                                {
                                    if(numbers[i] < number) newList.Add(numbers[i]);
                                }

                                Console.WriteLine(string.Join(" ",newList));
                                break;
                            case ">":
                                for (int i = 0; i < numbers.Count; i++)
                                {
                                    if (numbers[i] > number) newList.Add(numbers[i]);
                                }

                                Console.WriteLine(string.Join(" ", newList));
                                break;
                            case ">=":
                                for (int i = 0; i < numbers.Count; i++)
                                {
                                    if (numbers[i] >= number) newList.Add(numbers[i]);
                                }

                                Console.WriteLine(string.Join(" ", newList));
                                break;
                            case "<=":
                                for (int i = 0; i < numbers.Count; i++)
                                {
                                    if (numbers[i] <= number) newList.Add(numbers[i]);
                                }

                                Console.WriteLine(string.Join(" ", newList));
                                break;
                        }
                        
                        break;

                }
            }
        }
    }
}