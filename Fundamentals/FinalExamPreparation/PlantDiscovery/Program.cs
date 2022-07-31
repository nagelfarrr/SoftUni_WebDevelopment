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
                                    flower.AddRate(rating);
                                    break;

                                case "Update":
                                    int rarity = int.Parse(commands[2]);
                                    flower.Rarity = rarity;
                                    break;
                                case "Reset":
                                    flower.Rating.Clear();
                                    flower.average = 0;
                                    break;
                            }
                        }

                    }
                }
            }

            Console.WriteLine("Plants for the exhibition:");

            foreach (var flower in flowersList)
            {
                Console.WriteLine($"- {flower.Name}; Rarity: {flower.Rarity}; Rating: {flower.average:f2}");
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
            public double average;

            public void AddRate(double rate)
            {
                this.average = 0;
                this.Rating.Add(rate);
                for (int i = 0; i < this.Rating.Count; i++)
                {
                    average += this.Rating[i];
                }
                average /= this.Rating.Count;
            }
        }
    }
}
