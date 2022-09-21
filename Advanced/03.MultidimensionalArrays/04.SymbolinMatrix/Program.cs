using System;
using System.Linq;

namespace _04.SymbolinMatrix
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int matrixSize = int.Parse(Console.ReadLine());

            int[,] matrix = new int[matrixSize, matrixSize];

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                string input = Console.ReadLine();

                char[] rowData = input.ToCharArray();

                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row,col] = rowData[col];
                }
            }

            char symbolToFind = char.Parse(Console.ReadLine());

            bool isSymbolFound = false;
            for (int row = 0; row < matrix.GetLength(0); row++)
            {

                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    if (matrix[row, col] == symbolToFind)
                    {
                        isSymbolFound = true;
                        Console.WriteLine($"({row}, {col})");
                        return;
                    }
                    
                }
            }

            if (!isSymbolFound)
            {
                Console.WriteLine($"{symbolToFind} does not occur in the matrix");
            }
        }
    }
}
