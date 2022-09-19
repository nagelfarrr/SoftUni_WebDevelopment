using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

namespace _07.TruckTour
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int numberOfPumps = int.Parse(Console.ReadLine());



            Queue<int[]> pumpStack = new Queue<int[]>();


            for (int i = 0; i < numberOfPumps; i++)
            {
                int[] inputs = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
                pumpStack.Enqueue(inputs);
            }

            int startIndex = 0;

            while (true)
            {
                bool isComplete = true;
                int fuelTank = 0;
                foreach (var item in pumpStack)
                {
                    int liters = item[0];
                    int distance = item[1];
                    fuelTank += liters;

                    if (fuelTank - distance < 0)
                    {
                        startIndex++;
                        int[] currentPump = pumpStack.Dequeue();
                        pumpStack.Enqueue(currentPump);
                        isComplete = false;
                        break;
                    }
                    fuelTank -= distance;
                }

                if (isComplete)
                {
                    Console.WriteLine(startIndex);
                    break;
                }
            }

        }
    }
}
