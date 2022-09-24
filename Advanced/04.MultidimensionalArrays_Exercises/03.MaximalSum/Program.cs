using System;
using System.Linq;
using System.Numerics;
using System.Runtime.ExceptionServices;
using System.Runtime.Serialization;

namespace _03.MaximalSum
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] sizes = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(n => int.Parse(n))
                .ToArray();

            int rows = sizes[0];
            int cols = sizes[1];

            int[,] rectangle = new int[rows, cols];

            for (int row = 0; row < rectangle.GetLength(0); row++)
            {
                int[] rowData = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .Select(n => int.Parse(n))
                    .ToArray();
                for (int col = 0; col < rectangle.GetLength(1); col++)
                {
                    rectangle[row, col] = rowData[col];
                }
            }


            int maxSum = int.MinValue;
            int rowSum = 0;
            int colSum = 0;

            for (int row = 0; row < rectangle.GetLength(0) - 2; row++)
            {
                for (int col = 0; col < rectangle.GetLength(1) - 2; col++)
                {
                    int currentSum =
                        rectangle[row, col] + rectangle[row, col + 1] + rectangle[row, col + 2] +
                        rectangle[row + 1, col] + rectangle[row + 1, col + 1] + rectangle[row + 1, col + 2] +
                        rectangle[row + 2, col] + rectangle[row + 2, col + 1] + rectangle[row + 2, col + 2];

                    if (currentSum > maxSum)
                    {
                        maxSum = currentSum;
                        rowSum = row;
                        colSum = col;
                    }
                }
            }

            Console.WriteLine($"Sum = {maxSum}");

            for (int row = rowSum; row < rowSum + 3; row++)
            {

                for (int col = colSum; col < colSum + 3; col++)
                {
                    Console.Write($"{rectangle[row, col]} ");
                }

                Console.WriteLine();
            }


        }
    }
}
