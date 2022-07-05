using System;
using System.Collections.Generic;
using System.Linq;

namespace _04.RawData
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberOfCars = int.Parse(Console.ReadLine());
            var cars = new List<Car>();
            for (int i = 0; i < numberOfCars; i++)
            {
                string[] input = Console.ReadLine().Split();
                string model = input[0];
                int engineSpeed = int.Parse(input[1]);
                int enginePower = int.Parse(input[2]);
                int cargoWeight = int.Parse(input[3]);
                string cargoType = input[4];

                var engine = new Engine(engineSpeed, enginePower);
                var cargo = new Cargo(cargoType, cargoWeight);
                var car = new Car(model, engine, cargo);
                cars.Add(car);
            }

            string typeOfCargo = Console.ReadLine();

            switch (typeOfCargo)
            {
                case "fragile":
                    var fragile = cars.FindAll(c => c.Cargo.Type == "fragile" && c.Cargo.Weight < 1000);
                    foreach (var car in fragile)
                    {
                        Console.WriteLine(car.Model);
                    }
                    break;

                case "flamable":
                    var flamable = cars.FindAll(c => c.Cargo.Type == "flamable" && c.Engine.Power > 250);
                    foreach (var car in flamable)
                    {
                        Console.WriteLine(car.Model);
                    }
                    break;
            }
        }
    }

    public class Car
    {
        public Car(string model, Engine engine, Cargo cargo)
        {
            this.Model = model;
            this.Engine = engine;
            this.Cargo = cargo;
        }

        public string Model { get; set; }
        public Engine Engine { get; set; }
        public Cargo Cargo { get; set; }
    }

    public class Engine
    {
        public Engine(int engineSpeed, int enginePower)
        {
            this.Speed = engineSpeed;
            this.Power = enginePower;
        }

        public int Speed { get; set; }
        public int Power { get; set; }
    }

    public class Cargo
    {

        public Cargo(string cargoType, int cargoWeight)
        {
            this.Type = cargoType;
            this.Weight = cargoWeight;
        }
        public string Type { get; set; }
        public int Weight { get; set; }
    }
}
