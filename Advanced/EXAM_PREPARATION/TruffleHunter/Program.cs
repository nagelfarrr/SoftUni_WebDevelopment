using System;
using System.Data;
using System.Drawing;
using System.Linq;


namespace TruffleHunter
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int blackTruffle = 0;
            int summerTruffle = 0;
            int whiteTruffle = 0;
            int eatenTruffles = 0;

            int size = int.Parse(Console.ReadLine());

            char[,] forestMatrix = new char[size, size];

            for (int row = 0; row < size; row++)
            {
                string rowInput = string.Join("", Console.ReadLine().Split(" "));
                for (int col = 0; col < size; col++)
                {
                    forestMatrix[row, col] = rowInput[col];

                }
            }

            string command = Console.ReadLine();

            while (command != "Stop the hunt")
            {
                if (command.StartsWith("Collect"))
                {
                    string[] collectTokens = command.Split(" ");
                    int row = int.Parse(collectTokens[1]);
                    int col = int.Parse(collectTokens[2]);

                    if (forestMatrix[row, col] == 'B')
                    {
                        forestMatrix[row, col] = '-';
                        blackTruffle++;
                    }
                    else if (forestMatrix[row, col] == 'S')
                    {
                        forestMatrix[row, col] = '-';
                        summerTruffle++;
                    }
                    else if (forestMatrix[row, col] == 'W')
                    {
                        forestMatrix[row, col] = '-';
                        whiteTruffle++;
                    }
                }
                else if (command.StartsWith("Wild_Boar"))
                {
                    string[] boarTokens = command.Split(" ");
                    int row = int.Parse(boarTokens[1]);
                    int col = int.Parse(boarTokens[2]);
                    string direction = boarTokens[3];

                    int nextRow = 0;
                    int nextCol = 0;
                    switch (direction)
                    {
                        case "up":

                            while (true)
                            {
                                if (forestMatrix[row, col] == 'B')
                                {
                                    forestMatrix[row, col] = '-';
                                    eatenTruffles++;
                                }
                                else if (forestMatrix[row, col] == 'S')
                                {
                                    forestMatrix[row, col] = '-';
                                    eatenTruffles++;

                                }
                                else if (forestMatrix[row, col] == 'W')
                                {
                                    forestMatrix[row, col] = '-';
                                    eatenTruffles++;

                                }

                                nextRow = row - 2;
                               
                                if (isDirectionValid(nextRow, nextCol, forestMatrix))
                                {
                                    row = nextRow;
                                    
                                }
                                else
                                {
                                    break;
                                }
                            }



                            break;
                        case "down":
                            while (true)
                            {
                                if (forestMatrix[row, col] == 'B')
                                {
                                    forestMatrix[row, col] = '-';
                                    eatenTruffles++;
                                }
                                else if (forestMatrix[row, col] == 'S')
                                {
                                    forestMatrix[row, col] = '-';
                                    eatenTruffles++;

                                }
                                else if (forestMatrix[row, col] == 'W')
                                {
                                    forestMatrix[row, col] = '-';
                                    eatenTruffles++;

                                }

                                nextRow = row + 2;

                                if (isDirectionValid(nextRow, nextCol, forestMatrix))
                                {
                                    row = nextRow;

                                }
                                else
                                {
                                    break;
                                }
                            }
                            break;
                        case "left":
                            while (true)
                            {
                                if (forestMatrix[row, col] == 'B')
                                {
                                    forestMatrix[row, col] = '-';
                                    eatenTruffles++;
                                }
                                else if (forestMatrix[row, col] == 'S')
                                {
                                    forestMatrix[row, col] = '-';
                                    eatenTruffles++;

                                }
                                else if (forestMatrix[row, col] == 'W')
                                {
                                    forestMatrix[row, col] = '-';
                                    eatenTruffles++;

                                }

                                nextCol = col - 2;

                                if (isDirectionValid(nextRow, nextCol, forestMatrix))
                                {
                                    col = nextCol;

                                }
                                else
                                {
                                    break;
                                }
                            }
                            break;
                        case "right":
                            while (true)
                            {
                                if (forestMatrix[row, col] == 'B')
                                {
                                    forestMatrix[row, col] = '-';
                                    eatenTruffles++;
                                }
                                else if (forestMatrix[row, col] == 'S')
                                {
                                    forestMatrix[row, col] = '-';
                                    eatenTruffles++;

                                }
                                else if (forestMatrix[row, col] == 'W')
                                {
                                    forestMatrix[row, col] = '-';
                                    eatenTruffles++;

                                }

                                nextCol = col + 2;

                                if (isDirectionValid(nextRow, nextCol, forestMatrix))
                                {
                                    col = nextCol;

                                }
                                else
                                {
                                    break;
                                }
                            }
                            break;
                    }

                }

                command = Console.ReadLine();
            }

            Console.WriteLine($"Peter manages to harvest {blackTruffle} black, {summerTruffle} summer, and {whiteTruffle} white truffles.");
            Console.WriteLine($"The wild boar has eaten {eatenTruffles} truffles.");
            PrintField(forestMatrix);
        }

        static bool isDirectionValid(int row, int col, char[,] matrix)
        {
            return (row >= 0 && row < matrix.GetLength(0) && col >= 0 && col < matrix.GetLength(1));
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
