using System;
using System.Collections;
using System.Collections.Generic;

namespace _08.TrafficJam
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int numberOfCarsToPass = int.Parse(Console.ReadLine());

            Queue<string> cars = new Queue<string>();
            int counter = 0;

            while (true)
            {
                string input = Console.ReadLine();

                if (input == "end")
                {
                    Console.WriteLine($"{counter} cars passed the crossroads.");
                    break;
                }
                else if (input == "green")
                {
                    for (int i = 0; i < numberOfCarsToPass; i++)
                    {
                        if (cars.Count > 0)
                        {
                            Console.WriteLine($"{cars.Dequeue()} passed!");
                            counter++;
                        }
                        else continue;
                    }
                }
                else
                {
                    cars.Enqueue(input);
                }

            }
        }
    }
}
