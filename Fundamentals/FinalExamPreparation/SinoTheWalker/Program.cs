using System;
using System.Globalization;

namespace SinoTheWalker
{
    internal class Program
    {
        static void Main(string[] args)
        {
            TimeSpan timeAtLeave = TimeSpan.Parse(Console.ReadLine());
            int numberOfSteps = int.Parse(Console.ReadLine());
            int secPerStep = int.Parse(Console.ReadLine());

            int secondsToWalk = secPerStep * numberOfSteps;

            TimeSpan timeToArive = TimeSpan.FromSeconds(secondsToWalk).Add(timeAtLeave);

            

            Console.WriteLine($"Time Arrival: {timeToArive.Hours:00}:{timeToArive.Minutes:00}:{timeToArive.Seconds:00}");

            
        }
    }
}
