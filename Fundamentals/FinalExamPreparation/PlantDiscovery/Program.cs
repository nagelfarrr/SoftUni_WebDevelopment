using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace PlantDiscovery
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int numberOfInitialInputs = int.Parse(Console.ReadLine());

            List<Flower> flowersList = new List<Flower>();

            for (int i = 0; i < numberOfInitialInputs; i++)
            {
                string[] initialInput = Console.ReadLine().Split("<->", StringSplitOptions.RemoveEmptyEntries);

                string flowerName = initialInput[0];
                int flowerRarity = int.Parse(initialInput[1]);

                Flower flower = new Flower(flowerName, flowerRarity);

                flowersList.Add(flower);
            }

            while (true)
            {
                string input = Console.ReadLine();
                if (input == "Exhibition") break;
                string[] delimeters = new string[] { ": ", " - " };
                string[] commands = input.Split(delimeters, StringSplitOptions.RemoveEmptyEntries);
                string cmd = commands[0];
                string plantName = commands[1];

                if (!flowersList.Exists(f => f.Name == plantName))
                {
                    Console.WriteLine("error");
                }
                else
                {
                    foreach (var flower in flowersList)
                    {
                        if (flower.Name == plantName)
                        {
                            switch (cmd)
                            {
                                case "Rate":
                                    double rating = double.Parse(commands[2]);
                                    flower.Rating.Add(rating);
                                    break;

                                case "Update":
                                    int rarity = int.Parse(commands[2]);
                                    flower.Rarity = 0;
                                    flower.Rarity = rarity;
                                    break;
                                case "Reset":
                                    flower.Rating.Clear();
                                    flower.Rating.Add(0.00);
                                    break;
                            }
                        }

                    }
                }
            }
            flowersList.Sort();
            Console.WriteLine("Plants for the exhibition:");
            foreach (var flower in flowersList)
            {
                Console.WriteLine($"- {flower.Name}; Rarity: {flower.Rarity}; Rating: {flower.Rating.Average():f2}");
            }
        }

        class Flower
        {
            public Flower(string flowerName, int flowerRarity)
            {
                this.Name = flowerName;
                this.Rarity = flowerRarity;
                this.Rating = new List<double>();
            }

            public string Name { get; set; }
            public int Rarity { get; set; }
            public List<double> Rating { get; set; }
        }
    }
}
