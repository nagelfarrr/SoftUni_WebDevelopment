using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace MirrorWords
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            string pattern = @"([@|#])(?<word>[A-Za-z]{4,})\1";

            MatchCollection matches = Regex.Matches(input, pattern);
            List<string> words = new List<string>();
            Dictionary<string, string> result = new Dictionary<string, string>();
            foreach (Match match in matches)
            {
                words.Add(match.Groups["word"].Value);
            }

            Console.WriteLine(string.Join(',',words));

            for (int i = 1; i < words.Count; i++)
            {
                if (words[i] == words[i-1].Reverse())
                {
                    if (!result.ContainsKey(words[i]))
                        result[words[i-1]] = words[i];
                }
            }

            foreach (var word in result)
            {
                Console.WriteLine($"{word.Value} <=> {word.Key}");
            }
        }
    }
}
