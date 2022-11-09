using System;

namespace Vehicles.Models
{
    public class Truck : Vehicle    
    {
        private const double AcFuelRate = 1.6;


        public Truck(double fuelQuantity, double fuelConsumption, double tankCapacity) : base(fuelQuantity, fuelConsumption, tankCapacity, AcFuelRate)
        {
        }

        public override void Refuel(double liters)
        {
            if (liters <= 0)
            {
                Console.WriteLine($"Fuel must be a positive number");
            }
            else if (this.FuelQuantity + liters * 0.95 > this.TankCapacity)
            {
                Console.WriteLine($"Cannot fit {liters} fuel in the tank");
            }
            else
            {
                base.Refuel(liters*0.95);
            }
        }
    }
}
