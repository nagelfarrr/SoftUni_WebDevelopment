using System;
using System.Collections.Generic;
using System.Linq;

namespace _09.PredicateParty
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<string> people = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .ToList();


            while (true)
            {
                string input = Console.ReadLine();
                
                if (input == "Party!")
                {
                    break;
                }

                string[] tokens = input.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string command = tokens[0];
                string criteria = tokens[1];
                string value = tokens[2];

                if (command == "Remove")
                {
                    people.RemoveAll(GetPredicate(criteria, value));
                }
                else if (command == "Double")
                {
                    var doubledPeople = people.FindAll(GetPredicate(criteria, value));
                    int index = people.FindIndex(GetPredicate(criteria, value));

                    if (index >= 0)
                    {
                        people.InsertRange(index,doubledPeople);
                    }
                }
            }

            if (people.Count > 0)
            {
                Console.WriteLine($"{string.Join(", ",people)} are going to the party!");

            }
            else
            {
                Console.WriteLine("Nobody is going to the party!");
            }
        }

        static Predicate<string> GetPredicate(string filter, string value)
        {
            switch (filter)
            {
                case "StartsWith":
                    return s => s.StartsWith(value);
                case "EndsWith":
                    return s => s.EndsWith(value);
                case "Length":
                    return s => s.Length == int.Parse(value);
                default:
                    return null;
            }
        }
    }
}
