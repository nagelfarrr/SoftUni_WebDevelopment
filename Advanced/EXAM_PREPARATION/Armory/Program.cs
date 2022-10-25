using System;
using System.ComponentModel.Design;

namespace Armory
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine());

            char[,] armory = new char[size, size];

            int currentRow = -1;
            int currentCol = -1;

            int goldSum = 0;

            for (int row = 0; row < size; row++)
            {
                string input = Console.ReadLine();
                for (int col = 0; col < size; col++)
                {
                    armory[row, col] = input[col];
                    if (armory[row, col] == 'A')
                    {
                        currentRow = row;
                        currentCol = col;
                    }
                }
            }

            bool isOut = false;

            while (true)
            {
                if (goldSum >= 65) break;
                string command = Console.ReadLine();
                isOut = false;
                switch (command)
                {
                    case "up":

                        if (currentRow == 0)
                        {
                            isOut = true;
                            armory[currentRow, currentCol] = '-';
                            break;
                        }

                        armory[currentRow, currentCol] = '-';
                        currentRow--;

                        if (armory[currentRow, currentCol] == 'M')
                        {
                            armory[currentRow, currentCol] = '-';
                            for (int row = 0; row < armory.GetLength(0); row++)
                            {
                                bool isTeleported = false;
                                for (int col = 0; col < armory.GetLength(1); col++)
                                {
                                    if (armory[row, col] == 'M')
                                    {
                                        currentRow = row;
                                        currentCol = col;
                                        isTeleported = true;
                                        armory[currentRow, currentCol] = 'A';
                                        break;
                                    }
                                }

                                if (isTeleported) break;
                            }

                        }
                        else
                        {
                            if (char.IsDigit(armory[currentRow, currentCol]))
                            {
                                goldSum += int.Parse(char.ToString(armory[currentRow, currentCol]));
                                armory[currentRow, currentCol] = 'A';
                            }

                            armory[currentRow, currentCol] = 'A';
                        }

                        break;
                    case "down":
                        if (currentRow == armory.GetLength(0)-1)
                        {
                            isOut = true;
                            armory[currentRow, currentCol] = '-';
                            break;
                        }

                        armory[currentRow, currentCol] = '-';
                        currentRow++;

                        if (armory[currentRow, currentCol] == 'M')
                        {
                            armory[currentRow, currentCol] = '-';
                            for (int row = 0; row < armory.GetLength(0); row++)
                            {
                                bool isTeleported = false;
                                for (int col = 0; col < armory.GetLength(1); col++)
                                {
                                    if (armory[row, col] == 'M')
                                    {
                                        currentRow = row;
                                        currentCol = col;
                                        isTeleported = true;
                                        armory[currentRow, currentCol] = 'A';
                                        break;
                                    }
                                }

                                if (isTeleported) break;
                            }

                        }
                        else
                        {
                            if (char.IsDigit(armory[currentRow, currentCol]))
                            {
                                goldSum += int.Parse(char.ToString(armory[currentRow, currentCol]));
                                armory[currentRow, currentCol] = 'A';
                            }

                            armory[currentRow, currentCol] = 'A';
                        }


                        break;
                    case "left":
                        if (currentCol == 0)
                        {
                            isOut = true;
                            armory[currentRow, currentCol] = '-';
                            break;
                        }

                        armory[currentRow, currentCol] = '-';
                        currentCol--;

                        if (armory[currentRow, currentCol] == 'M')
                        {
                            armory[currentRow, currentCol] = '-';
                            for (int row = 0; row < armory.GetLength(0); row++)
                            {
                                bool isTeleported = false;
                                for (int col = 0; col < armory.GetLength(1); col++)
                                {
                                    if (armory[row, col] == 'M')
                                    {
                                        currentRow = row;
                                        currentCol = col;
                                        isTeleported = true;
                                        armory[currentRow, currentCol] = 'A';
                                        break;
                                    }
                                }

                                if (isTeleported) break;
                            }

                        }
                        else
                        {
                            if (char.IsDigit(armory[currentRow, currentCol]))
                            {
                                goldSum += int.Parse(char.ToString(armory[currentRow, currentCol]));
                                armory[currentRow, currentCol] = 'A';
                            }

                            armory[currentRow, currentCol] = 'A';
                        }

                        break;
                    case "right":
                        if (currentCol == armory.GetLength(1)-1)
                        {
                            isOut = true;
                            armory[currentRow, currentCol] = '-';
                            break;
                        }

                        armory[currentRow, currentCol] = '-';
                        currentCol++;

                        if (armory[currentRow, currentCol] == 'M')
                        {
                            armory[currentRow, currentCol] = '-';
                            for (int row = 0; row < armory.GetLength(0); row++)
                            {
                                bool isTeleported = false;
                                for (int col = 0; col < armory.GetLength(1); col++)
                                {
                                    if (armory[row, col] == 'M')
                                    {
                                        currentRow = row;
                                        currentCol = col;
                                        isTeleported = true;
                                        armory[currentRow, currentCol] = 'A';
                                        break;
                                    }
                                }

                                if (isTeleported) break;
                            }

                        }
                        else
                        {
                            if (char.IsDigit(armory[currentRow, currentCol]))
                            {
                                goldSum += int.Parse(char.ToString(armory[currentRow, currentCol]));
                                armory[currentRow, currentCol] = 'A';
                            }

                            armory[currentRow, currentCol] = 'A';
                        }


                        break;
                }

                if (isOut) break;

            }

            if (isOut)
            {
                Console.WriteLine("I do not need more swords!");
            }
            else
            {
                Console.WriteLine("Very nice swords, I will come back for more!");
            }

            Console.WriteLine($"The king paid {goldSum} gold coins.");

            for (int row = 0; row < armory.GetLength(0); row++)
            {
                for (int col = 0; col < armory.GetLength(1); col++)
                {
                    Console.Write(armory[row, col]);
                }

                Console.WriteLine();
            }
        }



    }
}
