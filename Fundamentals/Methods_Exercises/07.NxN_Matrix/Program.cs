using System;

namespace _07.NxN_Matrix
{
    class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());
            GeneratingMatrix(number);

        }

        private static void GeneratingMatrix(int number)
        {
            for (int row = 0; row < number; row++)
            {
                //Console.Write(number);
                for (int col = 0; col < number; col++)
                {
                    Console.Write($"{number} ");
                }
                Console.WriteLine();
            }
        }
    }
}
