using System;
using System.Collections.Generic;
using System.Text;

namespace P_rates
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, City> cityInformation = new Dictionary<string, City>();

            while (true)
            {
                string sail = Console.ReadLine();
                if (sail == "Sail") break;
                string[] cities = sail.Split("||", StringSplitOptions.RemoveEmptyEntries);
                string cityName = cities[0];
                int population = int.Parse(cities[1]);
                int gold = int.Parse(cities[2]);

                if (!cityInformation.ContainsKey(cityName))
                {
                    cityInformation[cityName] = new City() { Population = population, Gold = gold };
                }
                else
                {
                    cityInformation[cityName].Population += population;
                    cityInformation[cityName].Gold += gold;
                }
            }

            while (true)
            {
                string input = Console.ReadLine();
                if (input == "End") break;
                string[] commands = input.Split("=>", StringSplitOptions.RemoveEmptyEntries);
                string command = commands[0];
                string cityName = commands[1];

                switch (command)
                {
                    case "Plunder":
                        int peopleToKill = int.Parse(commands[2]);
                        int goldToSteal = int.Parse(commands[3]);

                        Console.WriteLine($"{cityName} plundered! {goldToSteal} gold stolen, {peopleToKill} citizens killed.");

                        cityInformation[cityName].Population -= peopleToKill;
                        cityInformation[cityName].Gold -= goldToSteal;


                        if (cityInformation[cityName].Gold == 0 || cityInformation[cityName].Population == 0)
                        {
                            cityInformation.Remove(cityName);
                            Console.WriteLine($"{cityName} has been wiped off the map!");
                        }

                        break;

                    case "Prosper":
                        int goldToIncrease = int.Parse(commands[2]);

                        if (goldToIncrease <= 0)
                        {
                            Console.WriteLine("Gold added cannot be a negative number!");

                        }
                        else
                        {
                            cityInformation[cityName].Gold += goldToIncrease;
                            Console.WriteLine($"{goldToIncrease} gold added to the city treasury. {cityName} now has {cityInformation[cityName].Gold} gold.");
                        }
                        break;
                }

            }

            if (cityInformation.Count > 0)
            {
                Console.WriteLine($"Ahoy, Captain! There are {cityInformation.Count} wealthy settlements to go to:");
                foreach (var city in cityInformation)
                {
                    Console.WriteLine(
                        $"{city.Key} -> Population: {city.Value.Population} citizens, Gold: {city.Value.Gold} kg");
                }
            }
            else
            {
                Console.WriteLine("Ahoy, Captain! All targets have been plundered and destroyed!");
            }
        }
    }

    class City
    {
        public int Population { get; set; }
        public int Gold { get; set; }
    }
}
