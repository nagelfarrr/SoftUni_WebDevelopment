using System;

namespace PawnWars
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int size = 8;
            int blackRow = -1;
            int blackCol = -1;

            int whiteRow = -1;
            int whiteCol = -1;


            char[,] board = new char[size, size];

            for (int row = 0; row < size; row++)
            {
                string input = Console.ReadLine();
                for (int col = 0; col < size; col++)
                {
                    board[row, col] = input[col];
                    if (board[row, col] == 'b')
                    {
                        blackRow = row;
                        blackCol = col;
                    }

                    if (board[row, col] == 'w')
                    {
                        whiteRow = row;
                        whiteCol = col;
                    }
                }
            }

            bool isWhitePromoted = false;
            bool isBlackPromoted = false;
            bool isWhiteCaptured = false;
            bool isBlackCaptured = false;

            while (true)
            {
                //white move
                if (whiteRow - 1 >= 0)
                {

                    if (whiteRow - 1 == blackRow && whiteCol - 1 == blackCol)
                    {
                        board[whiteRow, whiteCol] = '-';
                        whiteRow--;
                        whiteCol--;
                        board[whiteRow, whiteCol] = 'w';
                        isBlackCaptured = true;
                        break;
                    }
                    else if (whiteRow - 1 == blackRow && whiteCol + 1 == blackCol)
                    {
                        board[whiteRow, whiteCol] = '-';
                        whiteRow--;
                        whiteCol++;
                        board[whiteRow, whiteCol] = 'w';
                        isBlackCaptured = true;
                        break;
                    }


                    else if (whiteRow - 1 > 0)
                    {
                        board[whiteRow, whiteCol] = '-';
                        whiteRow--;
                        //board[whiteRow, whiteCol] = 'w';
                    }
                    else if (whiteRow - 1 == 0)
                    {
                        board[whiteRow, whiteCol] = '-';
                        whiteRow--;
                        board[whiteRow, whiteCol] = 'w';
                        isWhitePromoted = true;
                        break;
                    }
                }

                //black move

                if (blackRow + 1 < size)
                {

                    if (blackRow +1 == whiteRow && blackCol -1 == whiteCol)
                    {
                        board[blackRow, blackCol] = '-';
                        blackRow++;
                        blackCol--;
                        board[blackRow, blackCol] = 'b';
                        isWhiteCaptured = true;
                        break;
                    }
                    else if (blackRow + 1 == whiteRow && blackCol + 1 == whiteCol)
                    {
                        board[blackRow, blackCol] = '-';
                        blackRow++;
                        blackCol++;
                        board[blackRow, blackCol] = 'b';
                        isWhiteCaptured = true;
                        break;
                    }


                    else if (blackRow + 1 < size - 1)
                    {
                        board[blackRow, blackCol] = '-';
                        blackRow++;
                        //board[blackRow, blackCol] = 'b';
                    }
                    else if (blackRow + 1 == size - 1)
                    {
                        board[blackRow, blackCol] = '-';
                        blackRow++;
                        board[blackRow, blackCol] = 'b';
                        isBlackPromoted = true;
                        break;

                    }
                }
            }

            if (isWhitePromoted)
            {
                Console.WriteLine($"Game over! White pawn is promoted to a queen at {GetWinnersCoordinates(board)}.");
            }
            else if (isBlackPromoted)
            {
                Console.WriteLine($"Game over! Black pawn is promoted to a queen at {GetWinnersCoordinates(board)}.");
            }
            else if (isWhiteCaptured)
            {
                Console.WriteLine($"Game over! Black capture on {GetWinnersCoordinates(board)}.");
            }
            else if (isBlackCaptured)
            {
                Console.WriteLine($"Game over! White capture on {GetWinnersCoordinates(board)}.");
            }

        }

        public static string GetWinnersCoordinates(char[,] board)
        {
            string coordinate = string.Empty;
            for (int row = 0; row < board.GetLength(0); row++)
            {
                bool isCoordinateFound = false;

                for (int col = 0; col < board.GetLength(1); col++)
                {

                    if (board[row, col] == 'w' || board[row, col] == 'b')
                    {
                        isCoordinateFound = true;
                        coordinate = (char)('a' + col) + (8 - row).ToString();
                    }

                }

                if (isCoordinateFound) break;

            }

            return coordinate;
        }
    }
}
