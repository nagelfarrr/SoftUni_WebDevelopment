﻿using System;
using System.Linq;

namespace _05.SnakeMoves
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] dimensions = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(n => int.Parse(n))
                .ToArray();
            int rows = dimensions[0];
            int cols = dimensions[1];

            string snake = Console.ReadLine();

            char[,] matrix = new char[rows, cols];

            int currentSnakeIndex = 0;

            for (int row = 0; row < matrix.GetLength(0); row++)
            {

                if (row % 2 == 0)
                {
                    for (int col = 0; col < matrix.GetLength(1); col++)
                    {
                        if (currentSnakeIndex == snake.Length)
                        {
                            currentSnakeIndex = 0;
                        }
                        matrix[row, col] = snake[currentSnakeIndex];
                        currentSnakeIndex++;

                    }
                }
                else
                {
                    for (int col = matrix.GetLength(1) - 1; col >= 0; col--)
                    {
                        if (currentSnakeIndex == snake.Length)
                        {
                            currentSnakeIndex = 0;
                        }
                        matrix[row, col] = snake[currentSnakeIndex];
                        currentSnakeIndex++;
                    }
                }
                
            }

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    Console.Write($"{matrix[row, col]}");
                }

                Console.WriteLine();
            }


        }
    }
}
