using System;
using System.Collections.Generic;

namespace SpeedRacing
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            int numberOfCars = int.Parse(Console.ReadLine());

            List<Car> cars = new List<Car>();
            for (int i = 0; i < numberOfCars; i++)
            {
                string[] input = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string model = input[0];
                double fuelAmount = double.Parse(input[1]);
                double fuelConsumptionPerKilometer = double.Parse(input[2]);
                Car car = new Car()
                {
                    Model = model,
                    FuelAmount = fuelAmount,
                    FuelConsumptionPerKilometer = fuelConsumptionPerKilometer
                };
                cars.Add(car);
            }

            while (true)
            {
                string input = Console.ReadLine();
                if (input == "End")
                    break;

                string[] tokens = input.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string carModel = tokens[1];
                int amountOfKm = int.Parse(tokens[2]);

                foreach (var car in cars)
                {
                    if (car.Model == carModel)
                    {
                        car.Drive(amountOfKm);
                    }
                }
            }

            foreach (var car in cars)
            {
                Console.WriteLine($"{car.Model} {car.FuelAmount:F2} {car.TravelledDistance}");
            }
        }
    }
}
