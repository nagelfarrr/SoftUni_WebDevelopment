using System;
using System.Collections.Generic;
using System.Linq;

namespace _07.VehicleCatalogue
{
    class Program
    {
        static void Main(string[] args)
        {
            CatalogVehicle catalogVehicle = new CatalogVehicle();
            List<CatalogVehicle> catalog = new List<CatalogVehicle>();
            while (true)
            {
                string input = Console.ReadLine();
                if (input == "end") break;

                string[] tokens = input.Split('/');

                switch (tokens[0])
                {
                    case "Car":
                        Car car = new Car
                        {
                            Brand = tokens[1],
                            Model = tokens[2],
                            HorsePower = int.Parse(tokens[3])
                        };
                        catalogVehicle.Cars.Add(car);
                        break;
                    case "Truck":
                        Truck truck = new Truck
                        {
                            Brand = tokens[1],
                            Model = tokens[2],
                            Weight = double.Parse(tokens[3])
                        };
                        catalogVehicle.Trucks.Add(truck);
                        break;
                }
            }

            if (catalogVehicle.Cars.Count > 0)
            {
                List<Car> orderedCars = catalogVehicle.Cars.OrderBy(c => c.Brand).ToList();
                Console.WriteLine("Cars:");
                foreach (var car in orderedCars)
                {
                    Console.WriteLine($"{car.Brand}: {car.Model} - {car.HorsePower}hp");
                }
            }

            if (catalogVehicle.Trucks.Count > 0)
            {
                List<Truck> orderedTrucks = catalogVehicle.Trucks.OrderBy(c => c.Brand).ToList();
                Console.WriteLine("Trucks:");
                foreach (var truck in orderedTrucks)
                {
                    Console.WriteLine($"{truck.Brand}: {truck.Model} - {truck.Weight}kg");
                }
            }

        }
    }

    public class Truck
    {
        public string Brand { get; set; }
        public string Model { get; set; }
        public double Weight { get; set; }
    }

    public class Car
    {
        public string Brand { get; set; }
        public string Model { get; set; }
        public int HorsePower { get; set; }
    }

    public class CatalogVehicle
    {
        public CatalogVehicle()
        {
            this.Cars = new List<Car>();
            this.Trucks = new List<Truck>();
        }
        public List<Car> Cars { get; set; }
        public List<Truck> Trucks { get; set; }
    }
}
