using System;
using System.Linq;

namespace _04.MatrixShuffling
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] matrixSize = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(n => int.Parse(n))
                .ToArray();

            int rows = matrixSize[0];
            int cols = matrixSize[1];

            string[,] matrix = new string[rows, cols];

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                string[] rowData = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = rowData[col];
                }
            }

            while (true)
            {
                string input = Console.ReadLine();
                if (input == "END")
                    break;

                string[] tokens = input.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                if (tokens.Length == 5)
                {
                    string command = tokens[0];
                    int row1 = int.Parse(tokens[1]);
                    int col1 = int.Parse(tokens[2]);
                    int row2 = int.Parse(tokens[3]);
                    int col2 = int.Parse(tokens[4]);

                    if (command != "swap" || row1 < 0 || row1 > rows || col1 < 0 || col1 > cols || row2 < 0 ||
                        row2 > rows || col2 < 0 || col2 > cols)
                    {
                        Console.WriteLine("Invalid input!");
                    }
                    else
                    {
                        (matrix[row1, col1], matrix[row2, col2]) = (matrix[row2, col2], matrix[row1, col1]);
                        PrintMatrix(matrix);
                    }
                }
                else
                {
                    Console.WriteLine("Invalid input!");
                }
            }

            static void PrintMatrix(string[,] matrix)
            {

                for (int row = 0; row < matrix.GetLength(0); row++)
                {
                    for (int col = 0; col < matrix.GetLength(1); col++)
                    {
                        Console.Write($"{matrix[row, col]} ");
                    }

                    Console.WriteLine();
                }
            }
        }
    }
}
