using System;
using System.Collections.Generic;
using System.Linq;

namespace _03.SpeedRacing
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberOfCars = int.Parse(Console.ReadLine());

            var cars = new List<Car>();

            for (int i = 0; i < numberOfCars; i++)
            {
                string[] input = Console.ReadLine().Split(' ');
                string model = input[0];
                double fuelAmount = double.Parse(input[1]);
                double fuelConsumption = double.Parse(input[2]);

                var car = new Car(model, fuelAmount, fuelConsumption);
                cars.Add(car);
            }

            while (true)
            {
                string[] input = Console.ReadLine().Split(' ');
                if (input[0] == "End") break;
                else
                {
                    string model = input[1];
                    int amountOfKm = int.Parse(input[2]);
                    var car = cars.FirstOrDefault(c => c.Model == model);
                    car.DriveCar(amountOfKm);
                }
            }

            foreach (var car in cars)
            {
                Console.WriteLine($"{car.Model} {car.FuelAmount:f2} {car.TraveledDistance}");
            }
        }
    }

    public class Car
    {
        public Car(string model, double fuelAmount, double fuelConsumption)
        {
            this.Model = model;
            this.FuelAmount = fuelAmount;
            this.FuelConsumption = fuelConsumption;
            this.TraveledDistance = 0;
        }

        public string Model { get; set; }
        public double FuelAmount { get; set; }
        public double FuelConsumption { get; set; }
        public double TraveledDistance { get; set; }


        public void DriveCar(int amountOfKm)
        {
            double fuelNeeded = FuelConsumption * amountOfKm;

            if(fuelNeeded > FuelAmount) Console.WriteLine("Insufficient fuel for the drive");
            else
            {
                FuelAmount -= fuelNeeded;
                TraveledDistance += amountOfKm;
            }

        }
    }
}
