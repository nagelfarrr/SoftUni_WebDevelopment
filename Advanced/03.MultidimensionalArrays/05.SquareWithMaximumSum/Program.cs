using System;
using System.Linq;

namespace _05.SquareWithMaximumSum
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] matrixSizes = Console.ReadLine().Split(", ").Select(int.Parse).ToArray();

            int rows = matrixSizes[0];
            int cols = matrixSizes[1];

            int[,] matrix = new int[rows, cols];

            for (int row = 0; row < rows; row++)
            {
                int[] rowsData = Console.ReadLine().Split(", ").Select(int.Parse).ToArray();

                for (int col = 0; col < cols; col++)
                {
                    matrix[row, col] = rowsData[col];
                }
            }

            int maxSum = int.MinValue;
            int rowIndex = -1;
            int colindex = -1;

            for (int row = 0; row < matrix.GetLength(0) -1; row++)
            {
                for (int col = 0; col < matrix.GetLength(1) -1; col++)
                {
                    int squareSum = matrix[row, col]
                                    + matrix[row, col + 1]
                                    + matrix[row + 1, col]
                                    + matrix[row + 1, col + 1];

                    if (squareSum > maxSum)
                    {
                        maxSum= squareSum;
                        rowIndex = row;
                        colindex = col;
                    }
                }
            }

            Console.WriteLine($"{matrix[rowIndex,colindex]} {matrix[rowIndex,colindex+1]}");
            Console.WriteLine($"{matrix[rowIndex+1,colindex]} {matrix[rowIndex+1,colindex+1]}");
            Console.WriteLine(maxSum);

        }
    }
}
