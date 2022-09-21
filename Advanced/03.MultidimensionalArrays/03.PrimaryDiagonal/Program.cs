using System;
using System.Diagnostics.CodeAnalysis;
using System.Linq;

namespace _03.PrimaryDiagonal
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int squareSize = int.Parse(Console.ReadLine());

            int[,] matrix = new int[squareSize, squareSize];

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                int[] rowData = Console.ReadLine().Split(" ").Select(int.Parse).ToArray();

                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = rowData[col];
                }
            }

            int sum = 0;
            int numToAdd = 0;
            for (int row = 0; row < matrix.GetLength(0); row++)
            {

                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    numToAdd = matrix[row, col];
                    row++;
                    sum += numToAdd;
                }
            }

            Console.WriteLine(sum);

        }
    }
}
