using System;
using System.Collections.Generic;
using System.Linq;


namespace BeaverAtWork
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine());
            Stack<char> branches = new Stack<char>();

            char[,] pond = new char[size, size];

            int totalBranches = 0;
            int currentRow = 0;
            int currentCol = 0;
            int gatheredBranches = 0;

            for (int row = 0; row < size; row++)
            {
                string input = string.Join("", Console.ReadLine().Split(" "));
                for (int col = 0; col < size; col++)
                {
                    pond[row, col] = input[col];
                    if (pond[row, col] == 'B')
                    {
                        currentRow = row;
                        currentCol = col;
                    }

                    if (char.IsLower(pond[row, col]))
                    {
                        totalBranches++;
                    }
                }
            }


            while (true)
            {
                string input = Console.ReadLine();
                if (input == "end") break;

                if (totalBranches == 0) break;

                switch (input)
                {
                    case "up":
                        if (currentRow - 1 >= 0)
                        {
                            pond[currentRow, currentCol] = '-';
                            currentRow--;
                            if (isFish(currentRow, currentCol, pond))
                            {
                                pond[currentRow, currentCol] = '-';
                                if (currentRow == 0)
                                {
                                    currentRow = pond.GetLength(0) - 1;
                                    if (char.IsLower(pond[currentRow, currentCol]))
                                    {
                                        gatheredBranches++;
                                        branches.Push(pond[currentRow, currentCol]);
                                        totalBranches--;
                                    }
                                    pond[currentRow, currentCol] = 'B';
                                }
                                else
                                {
                                    currentRow = 0;
                                    if (char.IsLower(pond[currentRow, currentCol]))
                                    {
                                        gatheredBranches++;
                                        branches.Push(pond[currentRow, currentCol]);
                                        totalBranches--;
                                    }
                                    pond[currentRow, currentCol] = 'B';
                                }
                            }
                            else
                            {

                                if (char.IsLower(pond[currentRow, currentCol]))
                                {
                                    gatheredBranches++;
                                    branches.Push(pond[currentRow, currentCol]);
                                    totalBranches--;
                                }
                                pond[currentRow, currentCol] = 'B';
                            }

                        }
                        else if (currentRow - 1 < 0)
                        {
                            if (gatheredBranches > 0)
                                gatheredBranches--;
                            if (branches.Any())
                                branches.Pop();
                            continue;
                        }
                        break;
                    case "down":
                        if (currentRow + 1 <= pond.GetLength(0) - 1)
                        {
                            pond[currentRow, currentCol] = '-';
                            currentRow++;
                            if (isFish(currentRow, currentCol, pond))
                            {
                                pond[currentRow, currentCol] = '-';
                                if (currentRow == pond.GetLength(0) - 1)
                                {
                                    currentRow = 0;
                                    if (char.IsLower(pond[currentRow, currentCol]))
                                    {
                                        gatheredBranches++;
                                        branches.Push(pond[currentRow, currentCol]);
                                        totalBranches--;
                                    }
                                    pond[currentRow, currentCol] = 'B';
                                }
                                else
                                {
                                    currentRow = pond.GetLength(0) - 1;
                                    if (char.IsLower(pond[currentRow, currentCol]))
                                    {
                                        gatheredBranches++;
                                        branches.Push(pond[currentRow, currentCol]);
                                        totalBranches--;
                                    }
                                    pond[currentRow, currentCol] = 'B';
                                }
                            }
                            else
                            {

                                if (char.IsLower(pond[currentRow, currentCol]))
                                {
                                    gatheredBranches++;
                                    branches.Push(pond[currentRow, currentCol]);
                                    totalBranches--;
                                }
                                pond[currentRow, currentCol] = 'B';
                            }

                        }
                        else if (currentRow + 1 > pond.GetLength(0) - 1)
                        {
                            if (gatheredBranches > 0)
                                gatheredBranches--;
                            if (branches.Any())
                                branches.Pop();
                            continue;
                        }
                        break;
                    case "left":
                        if (currentCol - 1 >= 0)
                        {
                            pond[currentRow, currentCol] = '-';
                            currentCol--;
                            if (isFish(currentRow, currentCol, pond))
                            {
                                pond[currentRow, currentCol] = '-';
                                if (currentCol == 0)
                                {
                                    currentCol = pond.GetLength(1) - 1;
                                    if (char.IsLower(pond[currentRow, currentCol]))
                                    {
                                        gatheredBranches++;
                                        branches.Push(pond[currentRow, currentCol]);
                                        totalBranches--;
                                    }
                                    pond[currentRow, currentCol] = 'B';
                                }
                                else
                                {
                                    currentCol = 0;
                                    if (char.IsLower(pond[currentRow, currentCol]))
                                    {
                                        gatheredBranches++;
                                        branches.Push(pond[currentRow, currentCol]);
                                        totalBranches--;
                                    }
                                    pond[currentRow, currentCol] = 'B';
                                }
                            }
                            else
                            {

                                if (char.IsLower(pond[currentRow, currentCol]))
                                {
                                    gatheredBranches++;
                                    branches.Push(pond[currentRow, currentCol]);
                                    totalBranches--;
                                }
                                pond[currentRow, currentCol] = 'B';
                            }

                        }
                        else if (currentCol - 1 < 0)
                        {
                            if (gatheredBranches > 0)
                                gatheredBranches--;
                            if (branches.Any())
                                branches.Pop();
                            continue;
                        }
                        break;
                    case "right":
                        if (currentCol + 1 <= pond.GetLength(1) - 1)
                        {
                            pond[currentRow, currentCol] = '-';
                            currentCol++;
                            if (isFish(currentRow, currentCol, pond))
                            {
                                pond[currentRow, currentCol] = '-';
                                if (currentCol == pond.GetLength(1) - 1)
                                {
                                    currentCol = 0;
                                    if (char.IsLower(pond[currentRow, currentCol]))
                                    {
                                        gatheredBranches++;
                                        branches.Push(pond[currentRow, currentCol]);
                                        totalBranches--;
                                    }
                                    pond[currentRow, currentCol] = 'B';
                                }
                                else
                                {
                                    currentCol = pond.GetLength(1) - 1;
                                    if (char.IsLower(pond[currentRow, currentCol]))
                                    {
                                        gatheredBranches++;
                                        branches.Push(pond[currentRow, currentCol]);
                                        totalBranches--;
                                    }
                                    pond[currentRow, currentCol] = 'B';
                                }
                            }
                            else
                            {

                                if (char.IsLower(pond[currentRow, currentCol]))
                                {
                                    gatheredBranches++;
                                    branches.Push(pond[currentRow, currentCol]);
                                    totalBranches--;
                                }
                                pond[currentRow, currentCol] = 'B';
                            }

                        }
                        else if (currentCol + 1 > pond.GetLength(1) - 1)
                        {
                            if (gatheredBranches > 0)
                                gatheredBranches--;
                            if (branches.Any())
                                branches.Pop();
                            continue;
                        }
                        break;
                }
            }


            if (totalBranches == 0)
            {
                Console.WriteLine($"The Beaver successfully collect {gatheredBranches} wood branches: {string.Join(", ", branches.Reverse())}.");
            }
            else
            {
                Console.WriteLine($"The Beaver failed to collect every wood branch. There are {totalBranches} branches left.");
            }
            PrintField(pond);
        }

        private static bool isFish(int row, int col, char[,] matrix)
        {
            return matrix[row, col] == 'F';
        }

        private static void PrintField(char[,] matrix)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    Console.Write(matrix[row, col] + " ");
                }

                Console.WriteLine();
            }
        }
    }
}
