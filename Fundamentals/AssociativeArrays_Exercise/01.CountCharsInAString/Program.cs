using System;
using System.Collections.Generic;
using System.Linq;

namespace _01.CountCharsInAString
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            List<char> chrList = new List<char>();

            for (int i = 0; i < input.Length; i++)
            {
                chrList.Add(input[i]);
            }

            Dictionary<char, int> charOccurrences = new Dictionary<char, int>();

            for (int i = 0; i < chrList.Count; i++)
            {
                if (!charOccurrences.ContainsKey(chrList[i]) && chrList[i] != ' ')
                {
                    charOccurrences.Add(chrList[i], 1);
                }
                else if (charOccurrences.ContainsKey(chrList[i]) && chrList[i] != ' ')
                {
                    charOccurrences[chrList[i]]++;
                }
            }

            foreach (var chr in charOccurrences)
            {
                Console.WriteLine($"{chr.Key} -> {chr.Value}");
            }
        }
    }
}
