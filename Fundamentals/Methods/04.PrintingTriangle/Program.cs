using System;

namespace _04.PrintingTriangle
{
    class Program
    {
        static void Main(string[] args)
        {
            int triangleLength = int.Parse(Console.ReadLine());
            PrintTriangle(triangleLength);
        }

         static void PrintTriangle(int triangleLength)
        {
            for (int i = 1; i <= triangleLength; i++)
            {
                PrintLine(1, i);
            }

            for (int j = triangleLength - 1; j >= 1; j--)
            {
                PrintLine(1, j);
            }
        }

        static void PrintLine(int start, int end)
        {
            for (int i = start; i <= end; i++)
            {
                Console.Write(i + " ");
            }
            Console.WriteLine();
        }
    }
}
