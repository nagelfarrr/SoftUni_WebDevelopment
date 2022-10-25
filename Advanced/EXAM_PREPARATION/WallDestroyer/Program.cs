using System;

namespace WallDestroyer
{
    internal class Program
    {
        static void Main(string[] args)
        {

            char rod = 'R';
            char cable = 'C';
            char vanko = 'V';
            char hole = '*';

            int size = int.Parse(Console.ReadLine());

            int currentRow = 0;
            int currentCol = 0;
            char[,] wall = new char[size, size];

            for (int row = 0; row < size; row++)
            {
                string input = Console.ReadLine();
                for (int col = 0; col < size; col++)
                {
                    wall[row, col] = input[col];
                    if (input[col] == vanko)
                    {
                        currentRow = row;
                        currentCol = col;
                    }
                }
            }

            string command = Console.ReadLine().ToLower();
            int holes = 1;
            int rods = 0;
            bool isElectrocuted = false;
            wall[currentRow, currentCol] = hole;
            while (command != "end")
            {
                int oldRow = currentRow;
                int oldCol = currentCol;

                switch (command)
                {
                    case "up":
                        currentRow--;
                        break;
                    case "down":
                        currentRow++;
                        break;
                    case "left":
                        currentCol--;
                        break;
                    case "right":
                        currentCol++;
                        break;
                    default:
                        break;
                }

                if (currentRow >= 0 && currentRow < size && currentCol >= 0 && currentCol < size)
                {
                    if (wall[currentRow, currentCol] == rod)
                    {
                        Console.WriteLine("Vanko hit a rod!");
                        rods++;
                        currentRow = oldRow;
                        currentCol = oldCol;
                    }
                    else if (wall[currentRow, currentCol] == '-')
                    {
                        holes++;
                        wall[currentRow, currentCol] = hole;
                    }
                    else if (wall[currentRow, currentCol] == hole)
                    {
                        Console.WriteLine($"The wall is already destroyed at position [{currentRow}, {currentCol}]!");
                    }
                    else if (wall[currentRow, currentCol] == cable)
                    {
                        wall[currentRow, currentCol] = 'E';
                        isElectrocuted = true;
                        holes++;
                        break;
                    }
                }
                else
                {
                    currentRow = oldRow;
                    currentCol = oldCol;
                }

                command = Console.ReadLine().ToLower();
            }

            if(isElectrocuted)
                Console.WriteLine($"Vanko got electrocuted, but he managed to make {holes} hole(s).");
            else
            {
                Console.WriteLine($"Vanko managed to make {holes} hole(s) and he hit only {rods} rod(s).");
                wall[currentRow, currentCol] = vanko;
            }


            PrintField(size, wall);
        }

        private static void PrintField(int size, char[,] wall)
        {
            for (int row = 0; row < size; row++)
            {
                for (int col = 0; col < size; col++)
                {
                    Console.Write(wall[row, col]);
                }

                Console.WriteLine();
            }
        }
    }
}
