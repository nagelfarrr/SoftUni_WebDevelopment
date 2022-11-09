namespace Vehicles
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Models;
    using Vehicles.Models.Contracts;


    public class StartUp
    {
        static void Main(string[] args)
        {
            HashSet<Vehicle> vehicles = new HashSet<Vehicle>();
            
            vehicles.Add(CreateVehicle());
            vehicles.Add(CreateVehicle());
            vehicles.Add(CreateVehicle());

            int numberOFCommands = int.Parse(Console.ReadLine());

            for (int i = 0; i < numberOFCommands; i++)
            {

                DriveVehicle(vehicles);

            }

            foreach (var vehicle in vehicles)
            {
                Console.WriteLine(vehicle);
            }
        }


        public static Vehicle CreateVehicle()
        {
            string[] vehicleInput = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            string vehicleType = vehicleInput[0];
            double vehicleFuelQty = double.Parse(vehicleInput[1]);
            double vehicleFuelConsumption = double.Parse(vehicleInput[2]);
            double tankCapacity = double.Parse(vehicleInput[3]);

            Vehicle vehicle = null;

            if (vehicleType == "Car")
            {
                vehicle = new Car(vehicleFuelQty, vehicleFuelConsumption, tankCapacity);
            }
            else if (vehicleType == "Truck")
            {
                vehicle = new Truck(vehicleFuelQty, vehicleFuelConsumption, tankCapacity);
            }
            else if (vehicleType == "Bus")
            {
                vehicle = new Bus(vehicleFuelQty, vehicleFuelConsumption, tankCapacity);
            }

            return vehicle;
        }

        private static void DriveVehicle(HashSet<Vehicle> vehicles)
        {
            string[] commands = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            string cmdType = commands[0];
            string vehicleType = commands[1];
            double argument = double.Parse(commands[2]);

            Vehicle vehicle = vehicles.FirstOrDefault(v => v.GetType().Name == vehicleType);

            if (vehicle != null)
            {
                if (cmdType == "Drive")
                {
                    vehicle.Drive(argument);
                }
                else if (cmdType == "Refuel")
                {
                    vehicle.Refuel(argument);
                }
                else if (cmdType == "DriveEmpty")
                {
                    vehicle.DriveEmpty(argument);
                }
            }
        }
    }
}
