using System;
using System.Collections.Generic;
using System.Linq;

namespace CarSalesman
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            int numberOfEngines = int.Parse(Console.ReadLine());

            List<Engine> engines = new List<Engine>();
            List<Car> cars = new List<Car>();

            for (int i = 0; i < numberOfEngines; i++)
            {

                string[] input = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string engineModel = input[0];
                int enginePower = int.Parse(input[1]);


                Engine engine = new Engine(engineModel, enginePower);

                if (input.Length > 2)
                {
                    bool isDigit = char.IsDigit(input[2], 0);
                    if (isDigit)
                    {
                        int engineDisplacement = int.Parse(input[2]);
                        engine.Displacement = engineDisplacement;
                    }
                    else
                    {
                        string engineEfficiency = input[2];
                        engine.Efficiency = engineEfficiency;
                    }

                    if (input.Length > 3)
                    {
                        engine.Efficiency = input[3];
                    }

                }
                engines.Add(engine);
                

            }

            int numberOfCars = int.Parse(Console.ReadLine());

            for (int i = 0; i < numberOfCars; i++)
            {
                string[] input = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string carModel = input[0];
                Engine engine = engines.Find(e => e.Model == input[1]);


                Car car = new Car(carModel, engine);

                if (input.Length > 2)
                {
                    bool isDigit = char.IsDigit(input[2], 0);

                    if (isDigit)
                    {
                        int carWeight = int.Parse(input[2]);
                        car.Weight = carWeight;
                    }
                    else
                    {
                        string carColor = input[2];
                        car.Color = input[2];
                    }

                    if (input.Length > 3)
                    {
                        car.Color = input[3];
                    }
                }
                cars.Add(car);
            }

            foreach (var car in cars)
            {
                Console.WriteLine(car.ToString());
            }
        }
    }
}
