using System;
using System.Collections.Generic;

namespace _05.CitiesByContinentAndCountry
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, Dictionary<string, List<string>>> continents =
                new Dictionary<string, Dictionary<string, List<string>>>();

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string continent = input[0];
                string country = input[1];
                string city = input[2];

                if(!continents.ContainsKey(continent))
                    continents[continent] = new Dictionary<string, List<string>>();
                if (!continents[continent].ContainsKey(country))
                    continents[continent][country] = new List<string>();

                continents[continent][country].Add(city);

            }

            foreach (var continent in continents)
            {
                Console.WriteLine($"{continent.Key}:");
                foreach (var country in continent.Value)
                {
                    Console.WriteLine($"{country.Key} -> {string.Join(", ",country.Value)}");
                }
            }
        }
    }
}
