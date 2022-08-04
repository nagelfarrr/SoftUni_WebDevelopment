using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text.RegularExpressions;

namespace EmojiDetector
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string inputText = Console.ReadLine();
            BigInteger coolnessThreshold = 1;
            MatchCollection digitCollection = Regex.Matches(inputText, @"[0-9]");

            foreach (Match match in digitCollection)
            {
                int digit = int.Parse(match.Value);

                coolnessThreshold *= digit;
            }

            string emojiPattern = @"([\:]{2}|[\*]{2})(?<emoji>[A-Z]{1}[a-z]{2,})\1";

            MatchCollection emojiCollection = Regex.Matches(inputText, emojiPattern);

            List<string> validEmojis = new List<string>();
            foreach (Match match in emojiCollection)
            {
                int currEmojiPoints = 0;

                for (int i = 0; i < match.Groups["emoji"].Value.Length; i++)
                {
                    currEmojiPoints += match.Groups["emoji"].Value[i];
                }

                if (currEmojiPoints > coolnessThreshold)
                {
                    validEmojis.Add(match.Value);
                }
            }

            Console.WriteLine($"Cool threshold: {coolnessThreshold}");
            Console.WriteLine($"{emojiCollection.Count} emojis found in the text. The cool ones are:");
            foreach (var validEmoji in validEmojis)
            {
                Console.WriteLine(validEmoji);
            }
        }
    }
}
