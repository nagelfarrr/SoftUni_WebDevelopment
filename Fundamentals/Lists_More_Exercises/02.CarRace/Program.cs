using System;
using System.Linq;

namespace _02.CarRace
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] track = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            double leftPlayer = 0;
            double rightPlayer = 0;

            for (int i = 0; i < track.Length / 2; i++)
            {
                if (track[i] == 0) leftPlayer = leftPlayer * 0.8;
                else leftPlayer += track[i];
            }

            for (int i = track.Length - 1; i > track.Length / 2; i--)
            {
                if (track[i] == 0) rightPlayer = rightPlayer * 0.8;
                else rightPlayer += track[i];
            }

            if (leftPlayer == (int)leftPlayer && rightPlayer == (int)rightPlayer)
            {

                if (leftPlayer > rightPlayer) Console.WriteLine($"The winner is right with total time: {rightPlayer}");
                else Console.WriteLine($"The winner is left with total time: {leftPlayer}");
            }
            else
            {
                if (leftPlayer > rightPlayer) Console.WriteLine($"The winner is right with total time: {rightPlayer:f1}");
                else Console.WriteLine($"The winner is left with total time: {leftPlayer:f1}");
            }

        }
    }
}