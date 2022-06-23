using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _02.TheLift
{
    class Program
    {
        static void Main(string[] args)
        {
            int peopleWaiting = int.Parse(Console.ReadLine());
            List<int> stateOfLift = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToList();
            const int MAXPEOPLE = 4;
            

            for (int wagon = 0; wagon < stateOfLift.Count; wagon++)
            {
                for (int i = stateOfLift[wagon]; i < MAXPEOPLE; i++)
                {
                    stateOfLift[wagon]++;
                    peopleWaiting--;

                    if (peopleWaiting == 0)
                    {
                        if (stateOfLift.Sum() < (stateOfLift.Count) * MAXPEOPLE)
                        {
                            Console.WriteLine("The lift has empty spots!");
                        }

                        Console.WriteLine(string.Join(" ",stateOfLift));
                        return;
                    }
                }
            }

            Console.WriteLine($"There isn't enough space! {peopleWaiting} people in a queue!");
            Console.WriteLine(string.Join(" ", stateOfLift));
            
        }
    }
}
