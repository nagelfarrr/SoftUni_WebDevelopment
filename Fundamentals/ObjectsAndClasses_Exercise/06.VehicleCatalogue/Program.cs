using System;
using System.Collections.Generic;
using System.Linq;

namespace _06.VehicleCatalogue
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Vehicle> vehicles = new List<Vehicle>();
            List<Vehicle> trucks = new List<Vehicle>();
            List<Vehicle> cars = new List<Vehicle>();
            double averageTrucksHp = 0;
            double averageCarsHp = 0;

            while (true)
            {
                string input = Console.ReadLine();
                if (input == "End") break;
                string[] tokens = input.Split(' ');

                var vehicle = new Vehicle()
                {
                    Type = tokens[0],
                    Model = tokens[1],
                    Color = tokens[2],
                    Horsepower = int.Parse(tokens[3])
                };
                vehicles.Add(vehicle);


            }

            while (true)
            {
                string input = Console.ReadLine();
                if (input == "Close the Catalogue") break;

                foreach (var vehicle in vehicles)
                {
                    if (input == vehicle.Model)
                    {
                        
                        Console.WriteLine($"Type: {FirstLetterToUpper(vehicle.Type)}\nModel: {vehicle.Model}\nColor: {vehicle.Color}\nHorsepower: {vehicle.Horsepower}");
                    }
                }
            }

            foreach (var vehicle in vehicles)
            {
                if (vehicle.Type == "truck")
                {
                    averageTrucksHp += vehicle.Horsepower;
                    trucks.Add(vehicle);
                }
                else if(vehicle.Type == "car")
                {
                    averageCarsHp += vehicle.Horsepower;
                    cars.Add(vehicle);
                }
            }

            averageCarsHp = averageCarsHp / cars.Count;
            averageTrucksHp = averageTrucksHp / trucks.Count;

            if (cars.Count > 0)
            {
                Console.WriteLine($"Cars have average horsepower of: {averageCarsHp:f2}.");
            }
            else
            {
                Console.WriteLine($"Cars have average horsepower of: {0:f2}.");
            }

            if (trucks.Count > 0)
            {
                Console.WriteLine($"Trucks have average horsepower of: {averageTrucksHp:f2}.");
            }
            else
            {
                Console.WriteLine($"Trucks have average horsepower of: {0:f2}.");
            }



        }

        public static string FirstLetterToUpper(string str)
        {
            return char.ToUpper(str[0]) + str.Substring(1);
        }
    }

    public class Vehicle
    {
        public string Type { get; set; }
        public string Model { get; set; }
        public string Color { get; set; }
        public int Horsepower { get; set; }
    }
}
