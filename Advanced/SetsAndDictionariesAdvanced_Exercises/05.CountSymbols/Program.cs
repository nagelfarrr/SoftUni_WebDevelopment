using System;
using System.Collections.Generic;

namespace _05.CountSymbols
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string text = Console.ReadLine();

            SortedDictionary<char, int> occurrences = new SortedDictionary<char, int>();

            for (int i = 0; i < text.Length; i++)
            {
                if (!occurrences.ContainsKey(text[i]))
                    occurrences.Add(text[i], 0);

                occurrences[text[i]]++;
            }

            foreach (var occurrence in occurrences)
            {
                Console.WriteLine($"{occurrence.Key}: {occurrence.Value} time/s");
            }
        }
    }
}
