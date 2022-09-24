using System;
using System.Linq;

namespace _06.JaggedArrayManipulator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int rows = int.Parse(Console.ReadLine());

            int[][] jaggedArray = new int[rows][];

            for (int row = 0; row < rows; row++)
            {
                int[] cols = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .Select(n => int.Parse(n))
                    .ToArray();
                jaggedArray[row] = new int[cols.Length];

                for (int col = 0; col < jaggedArray[row].Length; col++)
                {
                    jaggedArray[row][col] = cols[col];
                }
            }


            for (int row = 1; row < rows; row++)
            {
                if (jaggedArray[row].Length == jaggedArray[row - 1].Length)
                {
                    for (int col = 0; col < jaggedArray[row].Length; col++)
                    {
                        jaggedArray[row][col] *= 2;
                        jaggedArray[row - 1][col] *= 2;
                    }
                }
                else
                {
                    for (int col = 0; col < jaggedArray[row].Length; col++)
                    {
                        jaggedArray[row][col] /= 2;
                        
                    }

                    for (int col = 0; col < jaggedArray[row-1].Length; col++)
                    {
                        jaggedArray[row - 1][col] /= 2;
                    }
                }
            }


            while (true)
            {
                string input = Console.ReadLine();
                if (input == "End")
                    break;

                string[] tokens = input.Split(' ');

                string command = tokens[0];
                int row = int.Parse(tokens[1]);
                int col = int.Parse(tokens[2]);
                int value = int.Parse(tokens[3]);

                if (row >= 0 && row < jaggedArray.Length && col >= 0 && col < jaggedArray[row].Length)
                {
                    if (command == "Add")
                        jaggedArray[row][col] += value;

                    else if(command =="Subtract")
                        jaggedArray[row][col] -= value;
                }
            }

            foreach (var row in jaggedArray)
            {
                for (int i = 0; i < row.Length; i++)
                {
                    Console.Write($"{row[i]} ");
                }

                Console.WriteLine();
            }
        }


    }
}