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
            int averageTrucksHp = 0;
            List<Vehicle> trucks = new List<Vehicle>();
            List<Vehicle> cars = new List<Vehicle>();
            int averageCarsHp = 0;

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
                if (vehicle.Type == "truck")
                {
                    averageTrucksHp += vehicle.Horsepower;
                }
                else
                {
                    averageCarsHp += vehicle.Horsepower;
                }
                
            }

            while (true)
            {
                string input = Console.ReadLine();
                if (input == "Close the Catalogue") break;

                foreach (var vehicle in vehicles)
                {
                    if (input == vehicle.Model)
                    {
                        Console.WriteLine($"Type: {vehicle.Type}\nModel: {vehicle.Model}\nColor: {vehicle.Color}\nHorsepower: {vehicle.Horsepower}");
                    }
                }
            }


            averageTrucksHp = averageTrucksHp / trucks.Count;
            averageCarsHp = averageCarsHp / cars.Count;
            Console.WriteLine($"Cars have average horsepower of: {averageCarsHp}.");
            Console.WriteLine($"Trucks have average horsepower of: {averageTrucksHp}.");
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
