using System;

namespace HelpAMole
{
    public class HelpAMole
    {
        public static int moleRow = -1;
        public static int moleCol = -1;
        public static char[,] playingField;

        public static int firstSpecialLocationRow = -1;
        public static int firstSpecialLocationCol = -1;
        public static int secondSpecialLocationRow = -1;
        public static int secondSpecialLocationCol = -1;

        public static int points = 0;

        static void Main()
        {
            //create the playing field
            int n = int.Parse(Console.ReadLine());
            playingField = new char[n, n];

            for (int row = 0; row < n; row++)
            {
                string input = Console.ReadLine();
                for (int col = 0; col < n; col++)
                {
                    playingField[row, col] = input[col];
                }
            }

            //find Mole's position
            for (int row = 0; row < n; row++)
            {
                for (int col = 0; col < n; col++)
                {
                    if (playingField[row, col] == 'M')
                    {
                        moleRow = row;
                        moleCol = col;
                        break;
                    }
                }
            }

            //find speacial locations' positions
            for (int row = 0; row < n; row++)
            {
                for (int col = 0; col < n; col++)
                {
                    if (playingField[row, col] == 'S')
                    {
                        if (firstSpecialLocationRow < 0 && firstSpecialLocationCol < 0)
                        {
                            firstSpecialLocationRow = row;
                            firstSpecialLocationCol = col;
                        }
                        else
                        {
                            secondSpecialLocationRow = row;
                            secondSpecialLocationCol = col;
                        }
                    }
                }
            }

            //start receiving directions
            string command = Console.ReadLine();
            while (command != "End" && points < 25)
            {
                if (command == "up")
                {
                    Move(-1, 0);
                }
                else if (command == "down")
                {
                    Move(1, 0);
                }
                else if (command == "left")
                {
                    Move(0, -1);
                }
                else if (command == "right")
                {
                    Move(0, 1);
                }
                command = Console.ReadLine();
            }
            if (points < 25)
            {
                Console.WriteLine($"Too bad! The Mole lost this battle!");
                Console.WriteLine($"The Mole lost the game with a total of {points} points.");
            }
            else
            {
                Console.WriteLine($"Yay! The Mole survived another game!");
                Console.WriteLine($"The Mole managed to survive with a total of {points} points.");
            }
            PrintMatrix(n);

        }

        // move around the playing field
        private static void Move(int row, int col)
        {
            if (isInside(moleRow + row, moleCol + col))
            {
                if (playingField[moleRow + row, moleCol + col] == '-')
                {
                    playingField[moleRow, moleCol] = '-';
                    moleRow += row;
                    moleCol += col;
                }
                else if (char.IsDigit(playingField[moleRow + row, moleCol + col]))
                {
                    playingField[moleRow, moleCol] = '-';
                    moleRow += row;
                    moleCol += col;
                    points += int.Parse(playingField[moleRow, moleCol].ToString());
                    playingField[moleRow, moleCol] = 'M';
                }
                else if (playingField[moleRow + row, moleCol + col] == 'S')
                {
                    playingField[moleRow, moleCol] = '-';
                    moleRow += row;
                    moleCol += col;
                    if (moleRow == firstSpecialLocationRow && moleCol == firstSpecialLocationCol)
                    {
                        moleRow = secondSpecialLocationRow;
                        moleCol = secondSpecialLocationCol;
                        playingField[firstSpecialLocationRow, firstSpecialLocationCol] = '-';
                    }
                    else if (moleRow == secondSpecialLocationRow && moleCol == secondSpecialLocationCol)
                    {
                        moleRow = firstSpecialLocationRow;
                        moleCol = firstSpecialLocationCol;
                        playingField[secondSpecialLocationRow, secondSpecialLocationCol] = '-';

                    }
                    points -= 3;
                }
                playingField[moleRow, moleCol] = 'M';
            }
            else
            {
                Console.WriteLine("Don't try to escape the playing field!");
            }
        }

        //check if is inside the playing field
        private static bool isInside(int row, int col)
        {
            return row >= 0 && row < playingField.GetLength(0) && col >= 0 && col < playingField.GetLength(1);
        }

        //print matrix
        private static void PrintMatrix(int n)
        {
            for (int row = 0; row < n; row++)
            {
                for (int col = 0; col < n; col++)
                {
                    Console.Write(playingField[row, col]);
                }
                Console.WriteLine();
            }
        }
    }
}
