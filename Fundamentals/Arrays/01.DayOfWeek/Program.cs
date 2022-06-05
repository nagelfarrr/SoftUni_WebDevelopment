using System;

namespace _01.DayOfWeek
{
    class Program
    {
        static void Main(string[] args)
        {
            int input = int.Parse(Console.ReadLine());

            string[] daysOfWeek =
            {
                "Monday",
                "Tuesday",
                "Wednesday",
                "Thursday",
                "Friday",
                "Saturday",
                "Sunday"
            };

            if (input > 0 && input <= 7)
            {
                string currentDay = daysOfWeek[input - 1];
                Console.WriteLine(currentDay);
            }
            else
            {
                Console.WriteLine("Invalid day!");
            }
        }
    }
}
