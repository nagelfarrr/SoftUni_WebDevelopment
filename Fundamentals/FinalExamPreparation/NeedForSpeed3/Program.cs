using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices.ComTypes;

namespace NeedForSpeed3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int numberOfCarsToObtain = int.Parse(Console.ReadLine());

            Dictionary<string, Car> cars = new Dictionary<string, Car>();

            for (int i = 0; i < numberOfCarsToObtain; i++)
            {
                string[] input = Console.ReadLine().Split('|');
                string carModel = input[0];
                int mileage = int.Parse(input[1]);
                int fuel = int.Parse(input[2]);

                Car currCar = new Car(mileage, fuel);

                if (!cars.ContainsKey(carModel))
                {
                    cars[carModel] = currCar;
                }
            }

            while (true)
            {
                string input = Console.ReadLine();
                if (input == "Stop") break;
                string[] commands = input.Split(" : ", StringSplitOptions.RemoveEmptyEntries);

                string cmd = commands[0];
                string carModel = commands[1];

                switch (cmd)
                {
                    case "Drive":
                        int distance = int.Parse(commands[2]);
                        int fuelNeeded = int.Parse(commands[3]);

                        if (cars[carModel].Fuel < fuelNeeded)
                        {
                            Console.WriteLine("Not enough fuel to make that ride");
                        }
                        else
                        {
                            cars[carModel].Mileage += distance;
                            cars[carModel].Fuel -= fuelNeeded;
                            Console.WriteLine($"{carModel} driven for {distance} kilometers. {fuelNeeded} liters of fuel consumed.");
                        }

                        if (cars[carModel].Mileage >= 100000)
                        {
                            cars.Remove(carModel);
                            Console.WriteLine($"Time to sell the {carModel}!");
                        }
                        break;
                    case "Refuel":
                        int fuelToRefill = int.Parse(commands[2]);
                        int refilledFuel = 0;
                        bool isRefillPossible = true;
                        while (true)
                        {
                            if (cars[carModel].Fuel < 75 && fuelToRefill >0)
                            {
                                isRefillPossible = true;
                            }
                            else
                            {
                                isRefillPossible = false;
                            }

                            if (isRefillPossible)
                            {
                                fuelToRefill--;
                                refilledFuel++;
                                cars[carModel].Fuel++;
                            }
                            else
                            {
                                break;
                            }
                        }

                        Console.WriteLine($"{carModel} refueled with {refilledFuel} liters");

                        break;
                    case "Revert":
                        int kilometersToRevert = int.Parse(commands[2]);

                        cars[carModel].Mileage -= kilometersToRevert;

                        if (cars[carModel].Mileage < 10000)
                        {
                            cars[carModel].Mileage = 10000;
                        }
                        else
                        {
                            Console.WriteLine($"{carModel} mileage decreased by {kilometersToRevert} kilometers");
                        }

                        break;
                }
            }

            foreach (var car in cars)
            {
                Console.WriteLine($"{car.Key} -> Mileage: {car.Value.Mileage} kms, Fuel in the tank: {car.Value.Fuel} lt.");
            }
        }
    }

    class Car
    {
        public Car(int mileage, int fuel)
        {
            this.Mileage = mileage;
            this.Fuel = fuel;
        }

        public string Model { get; set; }
        public int Mileage { get; set; }
        public int Fuel { get; set; }

    }
}
