using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;

namespace _02.OddOccurrences
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] words = Console.ReadLine()
                .Split()
                .Select(w => w.ToLower())
                .ToArray();

            Dictionary<string, int> wordCounts = new Dictionary<string, int>();

            foreach (var word in words)
            {
                if (!wordCounts.ContainsKey(word)) wordCounts.Add(word, 0);
                wordCounts[word] += 1;
            }

            foreach (var wordCount in wordCounts)
            {
                if(wordCount.Value%2 !=0) Console.Write($"{wordCount.Key} ");
            }
        }
    }
}
