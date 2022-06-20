using System;
using System.Collections.Generic;
using System.Linq;

namespace _05.BombNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> sequence = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToList();

            int[] bomb = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            int numberToDetonate = bomb[0];
            int bombPower = bomb[1];

            for (int i = 0; i < sequence.Count; i++)
            {
                if (sequence.Contains(numberToDetonate))
                {
                    int indexToDetonate = sequence.IndexOf(numberToDetonate);
                    int explosion = 1 + bombPower + bombPower;

                    if (explosion/2 > sequence.l)
                    {
                        sequence.RemoveRange(indexToDetonate - bombPower, explosion-sequence.Count);
                    }


                    else if (explosion < sequence.Count - 1)
                        sequence.RemoveRange(indexToDetonate - bombPower, bombPower + bombPower + 1);
                }

            }

            Console.WriteLine(sequence.Sum());
        }
    }
}
