namespace Vehicles.Models
{
    using System;



    public class Car : Vehicle
    {
        private const double AcFuelRate = 0.9;

        public Car(double fuelQuantity, double fuelConsumption, double tankCapacity) : base(fuelQuantity, fuelConsumption, tankCapacity, AcFuelRate)
        {
        }
    }
}
