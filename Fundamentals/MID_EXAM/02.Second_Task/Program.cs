using System;
using System.Collections.Generic;
using System.Linq;

namespace _02.Second_Task
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> input = Console.ReadLine()
                .Split("||")
                .ToList();
            int fuel = int.Parse(Console.ReadLine());
            int ammunitions = int.Parse(Console.ReadLine());
            List<string> command = new List<string>();
            foreach (var route in input)
            {
                bool isMissionFailed = false;
                command = route.Split().ToList();


                switch (command[0])
                {
                    case "Travel":
                        int lightYears = int.Parse(command[1]);
                        if (fuel >= lightYears)
                        {
                            fuel -= lightYears;
                            Console.WriteLine($"The spaceship travelled {command[1]} light-years.");
                        }
                        else
                        {
                            Console.WriteLine("Mission failed.");
                            isMissionFailed = true;
                        }
                        break;
                    case "Enemy":
                        int armour = int.Parse(command[1]);
                        if (ammunitions >= armour)
                        {
                            ammunitions -= armour;
                            Console.WriteLine($"An enemy with {armour} armour is defeated.");
                        }
                        else
                        {
                            fuel = fuel - (armour * 2);
                            if (fuel >= 0)
                            {
                                Console.WriteLine($"An enemy with {armour} armour is outmaneuvered.");
                            }
                            else
                            {
                                Console.WriteLine("Mission failed.");
                                isMissionFailed = true;
                            }
                        }
                        break;
                    case "Repair":
                        int repairPoints = int.Parse(command[1]);
                        fuel += repairPoints;
                        ammunitions += repairPoints * 2;
                        Console.WriteLine($"Ammunitions added: {repairPoints*2}.");
                        Console.WriteLine($"Fuel added: {repairPoints}.");
                        break;
                    case "Titan":
                        Console.WriteLine($"You have reached {command[0]}, all passengers are safe.");
                        break;
                }

                if (isMissionFailed) break;
            }


        }
    }
}
