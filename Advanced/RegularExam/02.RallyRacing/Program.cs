using System;
using System.ComponentModel;
using System.Linq;

namespace _02.RallyRacing
{
    internal class Program
    {
        static void Main(string[] args)
        {
            char car = 'C';
            int carRow = 0;
            int carCol = 0;
            int size = int.Parse(Console.ReadLine());
            string carNumber = Console.ReadLine();

            char[,] track = new char[size, size];

            for (int row = 0; row < size; row++)
            {
                string input = string.Join("", Console.ReadLine().Split(" "));
                for (int col = 0; col < size; col++)
                {
                    track[row, col] = input[col];
                }
            }
            track[carRow, carCol] = car;

            int kmMoved = 0;
            bool isFinished = false;
            while (true)
            {
                if (isFinished) break;
                string command = Console.ReadLine();
                if (command == "End")
                {
                    Console.WriteLine($"Racing car {carNumber} DNF.");
                    break;
                }

                switch (command)
                {
                    case "left":
                        if (carCol - 1 >= 0)
                        {
                            track[carRow, carCol] = '.';
                            carCol--;

                        }

                        break;
                    case "right":
                        if (carCol + 1 < track.GetLength(1))
                        {
                            track[carRow, carCol] = '.';
                            carCol++;

                        }

                        break;
                    case "up":
                        if (carRow - 1 >= 0)
                        {
                            track[carRow, carCol] = '.';
                            carRow--;

                            
                        }

                        break;
                    case "down":
                        if (carRow + 1 < track.GetLength(0))
                        {
                            track[carRow, carCol] = '.';
                            carRow++;

                            
                        }

                        break;
                }

                if (track[carRow, carCol] == 'T')
                {
                    track[carRow, carCol] = '.';
                    for (int row = 0; row < size; row++)
                    {
                        bool isTunnelPassed = false;
                        for (int col = 0; col < size; col++)
                        {
                            if (track[row, col] == 'T')
                            {
                                carRow = row;
                                carCol = col;
                                track[carRow, carCol] = car;
                                isTunnelPassed = true;
                                kmMoved += 30;
                                break;

                            }
                        }

                        if (isTunnelPassed) break;
                    }
                }
                else if (track[carRow, carCol] == 'F')
                {
                    track[carRow, carCol] = car;
                    kmMoved += 10;
                    Console.WriteLine($"Racing car {carNumber} finished the stage!");
                    isFinished = true;

                }
                else if (track[carRow, carCol] == '.')
                {
                    kmMoved += 10;
                    track[carRow, carCol] = car;
                }
            }

            Console.WriteLine($"Distance covered {kmMoved} km.");
            PrintTrack(track);
        }

        public static void PrintTrack(char[,] track)
        {

            for (int row = 0; row < track.GetLength(0); row++)
            {
                for (int col = 0; col < track.GetLength(1); col++)
                {
                    Console.Write(track[row, col]);
                }

                Console.WriteLine();
            }
        }
    }
}
