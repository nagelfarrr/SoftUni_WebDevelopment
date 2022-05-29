using System;

namespace _07.WaterOverflow
{
    class Program
    {
        static void Main(string[] args)
        {
            int inputNumber = int.Parse(Console.ReadLine());
            const int CAPACITY = 255;
            int litersPoured = 0;

            for (int i = 0; i < inputNumber; i++)
            {
                int litersInput = int.Parse(Console.ReadLine());
                litersPoured += litersInput;

                if(CAPACITY < litersPoured)
                {
                    Console.WriteLine("Insufficient capacity!");
                    litersPoured -= litersInput;
                }
                
            }
            Console.WriteLine($"{litersPoured}");
        }
    }
}
