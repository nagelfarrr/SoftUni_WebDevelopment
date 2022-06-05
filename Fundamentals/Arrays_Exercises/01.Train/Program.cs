using System;

namespace _01.Train
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberOfWagons = int.Parse(Console.ReadLine());
            int[] passengers = new int[numberOfWagons];

            int sum = 0;
            for (int i = 0; i < numberOfWagons; i++)
            {
                int input = int.Parse(Console.ReadLine());
                passengers[i] = input;
                sum += input;

            }

            Console.WriteLine(string.Join(" ", passengers));
            Console.WriteLine(sum);
        }
    }
}
