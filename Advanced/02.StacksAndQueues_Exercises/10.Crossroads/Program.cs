using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace _10.Crossroads
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int greenLightSeconds = int.Parse(Console.ReadLine());
            int freeWindowSeconds = int.Parse(Console.ReadLine());


            Queue<string> cars = new Queue<string>();

            string input = Console.ReadLine();
            int passedCars = 0;
            bool isCarHit = false;
            
            while (input != "END")
            {
                int tempGreen = greenLightSeconds;
                int tempFreeWindow = freeWindowSeconds;
                bool isFreeWindowUsed = false;
                if (input == "green" && cars.Count > 0)
                {
                    while (tempGreen > 0 && cars.Count > 0 && !isFreeWindowUsed)
                    {
                        string currCar = cars.Dequeue();

                        int carLength = currCar.Length;

                        while (carLength > 0)
                        {
                            
                            tempGreen--;
                            carLength--;

                            if (carLength == 0)
                            {
                                passedCars++;
                                break;
                            }
                            else if (carLength > 0 && tempGreen == 0)
                            {
                                tempGreen += tempFreeWindow;
                                tempFreeWindow = 0;
                                isFreeWindowUsed = true;

                                if (carLength > 0 && tempGreen == 0)
                                {
                                    string carParts = currCar.Substring(currCar.Length - carLength);
                                    isCarHit = true;
                                    Console.WriteLine($"A crash happened!\n{currCar} was hit at {carParts.First()}.");
                                }

                            }
                        }

                    }

                }
                else
                {
                    cars.Enqueue(input);
                }

                if (isCarHit)
                {
                    break;
                }

                input = Console.ReadLine();
            }

            if (!isCarHit)
            {
                Console.WriteLine($"Everyone is safe.\n{passedCars} total cars passed the crossroads.");
            }
        }
    }
}
