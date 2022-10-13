using System;
using System.Collections.Generic;
using System.Linq;

namespace _10.PartyReservationFilterMode
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<string> people = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .ToList();

            Dictionary<string, Predicate<string>> filters = new Dictionary<string, Predicate<string>>();

            while (true)
            {
                string input = Console.ReadLine();

                if (input == "Print")
                {
                    break;
                }

                string[] tokens = input.Split(";", StringSplitOptions.RemoveEmptyEntries);

                string command = tokens[0];
                string criteria = tokens[1];
                string value = tokens[2];

                if (command == "Add filter")
                {
                    filters.Add(criteria + value, GetPredicate(criteria, value));
                }
                else
                {
                    filters.Remove(criteria + value);
                }
            }

            foreach (var filter in filters)
            {
                people.RemoveAll(filter.Value);
            }

            Console.WriteLine(string.Join(" ", people));
        }

        static Predicate<string> GetPredicate(string filter, string value)
        {
            switch (filter)
            {
                case "Starts with":
                    return s => s.StartsWith(value);
                case "Ends with":
                    return s => s.EndsWith(value);
                case "Length":
                    return s => s.Length == int.Parse(value);
                case "Contains":
                    return s => s.Contains(value);
                default:
                    return default(Predicate<string>);
            }
        }
    }
}