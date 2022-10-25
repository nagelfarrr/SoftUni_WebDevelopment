using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SoftUniParking
{
    public class Parking
    {
        private List<Car> cars;
        private int capacity;

        public Parking(int capacity)
        {
            this.cars = new List<Car>();
            this.capacity = capacity;
        }


        public int Count
        {
            get { return this.cars.Count; }
        }

        public string AddCar(Car car)
        {
            if (this.cars.Any(c => c.RegistrationNumber == car.RegistrationNumber))
            {
                return "Car with that registration number, already exists!";

            }

            if (this.cars.Count == this.capacity)
            {
                return "Parking is full!";

            }

            this.cars.Add(car);
            return $"Successfully added new car {car.Make} {car.RegistrationNumber}";
        }

        public string RemoveCar(string registrationNumber)
        {
            if (this.cars.All(c => c.RegistrationNumber != registrationNumber))
            {
                return "Car with that registration number, doesn't exist!";
            }


            var car = this.cars.Find(c => c.RegistrationNumber == registrationNumber);
            this.cars.Remove(car);
            return $"Successfully removed {registrationNumber}";

        }

        public Car GetCar(string registrationNumber)
        {
            return this.cars.Find(c => c.RegistrationNumber == registrationNumber);
        }

        public void RemoveSetOfRegistrationNumber(List<string> registrationNumbers)
        {
            foreach (var registrationNumber in registrationNumbers)
            {
                this.RemoveCar(registrationNumber);
            }
        }
    }
}
