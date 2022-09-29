using System;
using System.Collections.Generic;

namespace _07.ParkingLot
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            HashSet<string> car = new HashSet<string>();
            while (input != "END")
            {
                string[] tokens = input.Split(", ", StringSplitOptions.RemoveEmptyEntries);
                string command = tokens[0];
                string carID = tokens[1];

                switch (command)
                {
                    case "IN":
                        car.Add(carID);
                        break;
                    case "OUT":
                        if (car.Contains(carID))
                            car.Remove(carID);
                        break;
                }

                input = Console.ReadLine();
            }

            if (car.Count > 0)
            {
                foreach (var id in car)
                {
                    Console.WriteLine(id);
                }
            }
            else
            {
                Console.WriteLine("Parking Lot is Empty");
            }
        }
    }
}
