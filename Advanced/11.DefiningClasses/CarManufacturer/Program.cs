using System;
using System.Collections.Generic;
using System.Linq;

namespace CarManufacturer
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            List<Tire> tiresList = new List<Tire>();
            List<Engine> engineList = new List<Engine>();
            List<Car> carList = new List<Car>();


            while (true)
            {

                //TO FIX

                string input = Console.ReadLine();

                if (input == "No more tires")
                {
                    break;
                }
                string[] tokens = input.Split(" ", StringSplitOptions.RemoveEmptyEntries);

                int year = int.Parse(tokens[0]);
                double pressure = double.Parse(tokens[1]);

                var tire = new Tire(year, pressure);

                tiresList.Add(tire);

            }

            while (true)
            {
                string input = Console.ReadLine();
                if (input == "Engines done")
                {
                    break;
                }

                string[] tokens = input.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                int horsePower = int.Parse(tokens[0]);
                double cubicCapacity = double.Parse(tokens[1]);

                var engine = new Engine(horsePower, cubicCapacity);

                engineList.Add(engine);
            }

            while (true)
            {
                string input = Console.ReadLine();
                if (input == "Show special")
                {
                    for (int i = 0; i < carList.Count; i++)
                    {
                        if (carList[i].Year >= 2017 && carList[i].Engine.HorsePower > 330 && (
                            carList[i].Tires.Sum(t => t.Pressure) >= 9 && carList[i].Tires.Sum(t => t.Pressure) <= 10))
                        {
                            carList[i].Drive(20);

                            Console.WriteLine($"Make: {carList[i].Make}\nModel: {carList[i].Model}\nYear: {carList[i].Year}\nHorsePowers: {carList[i].Engine.HorsePower}");
                        }
                    }
                    break;
                }

                string[] tokens = input.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string make = tokens[0];
                string model = tokens[1];
                int year = int.Parse(tokens[2]);
                double fuelQuantity = double.Parse(tokens[3]);
                double fuelConsumption = double.Parse(tokens[4]);
                int engineIndex = int.Parse(tokens[5]);
                int tiresIndex = int.Parse(tokens[6]);

                var engine = engineList[engineIndex];
                var tire = tiresList[tiresIndex];

                Tire[] tires = new Tire[4]
                {
                    new Tire(tire.Year, tire.Pressure),
                    new Tire(tire.Year, tire.Pressure),
                    new Tire(tire.Year, tire.Pressure),
                    new Tire(tire.Year, tire.Pressure),
                };
                var car = new Car(make, model, year, fuelQuantity, fuelConsumption, engine, tires);

                carList.Add(car);

            }



        }
    }
}
