namespace Vehicles.Models
{
    using Contracts;
    using System;


    public abstract class Vehicle : IVehicle
    {


        protected Vehicle(double fuelQuantity, double fuelConsumption, double tankCapacity, double acFuelRate)
        {
            if (fuelQuantity > tankCapacity)
            {
                this.FuelQuantity = 0;
            }
            else
            {
                this.FuelQuantity = fuelQuantity;
            }

            this.FuelConsumption = fuelConsumption + acFuelRate;
            this.TankCapacity = tankCapacity;
        }


        public double FuelQuantity { get; private set; }
        public double FuelConsumption { get; private set; }

        public double TankCapacity { get; private set; }

        public virtual void Drive(double distance)
        {
            double neededFuelToDrive = this.FuelConsumption * distance;

            if (neededFuelToDrive < this.FuelQuantity)
            {
                this.FuelQuantity -= neededFuelToDrive;
                Console.WriteLine($"{this.GetType().Name} travelled {distance} km");
            }
            else
            {
                Console.WriteLine($"{this.GetType().Name} needs refueling");
            }
        }

        public virtual void DriveEmpty(double distance)
        {
            double neededFuelToDrive = (this.FuelConsumption - 1.4) * distance;
            if (neededFuelToDrive < this.FuelQuantity)
            {
                this.FuelQuantity -= neededFuelToDrive;
                Console.WriteLine($"{this.GetType().Name} travelled {distance} km");
            }
            else
            {
                Console.WriteLine($"{this.GetType().Name} needs refueling");
            }
        }

        public virtual void Refuel(double liters)
        {
            if (liters <= 0)
            {
                Console.WriteLine($"Fuel must be a positive number");
            }
            else if (this.FuelQuantity + liters > this.TankCapacity)
            {
                Console.WriteLine($"Cannot fit {liters} fuel in the tank");

            }
            else
            {
                this.FuelQuantity += liters;
            }
        }

        public override string ToString()
        {
            return $"{this.GetType().Name}: {this.FuelQuantity:F2}";
        }
    }
}
