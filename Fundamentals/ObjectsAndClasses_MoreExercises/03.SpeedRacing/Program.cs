using System;
using System.Collections.Generic;

namespace _03.SpeedRacing
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Car> cars = new List<Car>();

            int numberOfCars = int.Parse(Console.ReadLine());
            double traveledDistance = 0;
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
                string cmd = Console.ReadLine();
                if (cmd == "End") break;
                string[] cmdArray = cmd.Split();
                string model = cmdArray[1];
                double amountOfKm = double.Parse(cmdArray[2]);
                
                foreach (var car in cars)
                {
                    if (car.Model == model)
                    {
                        amountOfKm = 
                        car.TraveledDistance(amountOfKm, car.FuelConsumption, car.FuelAmount);
                        traveledDistance += amountOfKm;
                    }
                }
            }

            foreach (var car in cars)
            {
                Console.WriteLine($"{car.Model} {car.FuelAmount:f2} {traveledDistance}");
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
        }
        public string Model { get; set; }
        public double FuelAmount { get; set; }
        public double FuelConsumption { get; set; }


        public double TraveledDistance(double amountOfKm, double fuelConsumption, double fuelAmount)
        {
            
            if (fuelConsumption*amountOfKm <= amountOfKm)
            {
                double traveledDistance = fuelConsumption * amountOfKm;
                fuelAmount = fuelAmount - traveledDistance;

            }
            else
            {
                Console.WriteLine("Insufficient fuel for the drive");
            }

            return fuelAmount;
        }
    }
}
