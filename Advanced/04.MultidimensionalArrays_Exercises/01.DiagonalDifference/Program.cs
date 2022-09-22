using System;
using System.Linq;
using System.Numerics;

namespace _01.DiagonalDifference
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int squareSize = int.Parse(Console.ReadLine());

            int[,] square = new int[squareSize, squareSize];

            for (int row = 0; row < square.GetLength(0); row++)
            {
                int[] rowData = Console.ReadLine().Split().Select(n => int.Parse(n)).ToArray();
                for (int col = 0; col < square.GetLength(1); col++)
                {
                    square[row, col] = rowData[col];
                }
            }

            int firstSum = 0;
            int secondSum = 0;

            for (int row = 0; row < square.GetLength(0); row++)
            {
                firstSum += square[row, row];

            }

            int squareRow = 0;
            for (int col = square.GetLength(1) - 1; col >= 0; col--)
            {
                secondSum += square[squareRow, col];
                squareRow++;
            }

            Console.WriteLine(Math.Abs(firstSum - secondSum));
        }
    }
}
