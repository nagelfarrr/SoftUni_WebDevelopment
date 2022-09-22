using System;
using System.Linq;

namespace _07.PascalTriangle
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int rows = int.Parse(Console.ReadLine());

            long[][] jaggedArray = new long[rows][];

            jaggedArray[0] = new long[]
            {
                1
            };
            
            for (int row = 1; row < rows; row++)
            {

                jaggedArray[row] = new long[row+1];
                jaggedArray[row][0] = 1;
                for (int col = 1; col < row; col++)
                {
                    jaggedArray[row][col] = jaggedArray[row-1][col] + jaggedArray[row - 1][col-1];
                }

                jaggedArray[row][row] = 1;
            }

            foreach (var row in jaggedArray)
            {
                Console.WriteLine(string.Join(" ", row));
            }
        }
    }
}
