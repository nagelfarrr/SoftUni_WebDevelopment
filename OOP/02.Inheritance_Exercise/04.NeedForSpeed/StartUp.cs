using System;

namespace NeedForSpeed
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            Vehicle vehicle = new Vehicle(21, 200);
            Motorcycle motorcycle = new Motorcycle(12, 200);
            RaceMotorcycle raceMotorcycle = new RaceMotorcycle(12, 200);
            CrossMotorcycle crossMotorcycle = new CrossMotorcycle(12, 200);
            Car car = new Car(12, 200);
            FamilyCar familyCar = new FamilyCar(12, 200);
            SportCar sportCar = new SportCar(12, 200);


            Console.WriteLine($"{vehicle.Fuel}");
            Console.WriteLine($"{motorcycle.Fuel}");
            Console.WriteLine($"{raceMotorcycle.Fuel}");
            Console.WriteLine($"{crossMotorcycle.Fuel}");
            Console.WriteLine($"{car.Fuel}");
            Console.WriteLine($"{familyCar.Fuel}");
            Console.WriteLine($"{sportCar.Fuel}");

            Console.WriteLine(new string('-', 50));
            Console.WriteLine("After driving..");
            Console.WriteLine(new string('-',50));
            
            vehicle.Drive(100);
            motorcycle.Drive(100);
            raceMotorcycle.Drive(100);
            crossMotorcycle.Drive(100);
            car.Drive(100);
            familyCar.Drive(100);
            sportCar.Drive(100);


            Console.WriteLine($"{vehicle.Fuel}");
            Console.WriteLine($"{motorcycle.Fuel}");
            Console.WriteLine($"{raceMotorcycle.Fuel}");
            Console.WriteLine($"{crossMotorcycle.Fuel}");
            Console.WriteLine($"{car.Fuel}");
            Console.WriteLine($"{familyCar.Fuel}");
            Console.WriteLine($"{sportCar.Fuel}");

        }
    }
}
