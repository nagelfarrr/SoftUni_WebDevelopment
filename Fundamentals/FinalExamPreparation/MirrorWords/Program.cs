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
            string pattern = @"\#{1}[A-z]{3,}\#{2}[A-z]{3,}\#{1}|\@{1}[A-z)]{3,}\@{2}[A-z]{3,}\@{1}";

            Regex regex = new Regex(pattern);

            MatchCollection matches = regex.Matches(input);

            List<string> pairs = new List<string>();

            foreach (Match match in matches)
            {
                pairs.Add(match.Value);
            }


            Dictionary<string, string> mirroredPairs = new Dictionary<string, string>();

            if (pairs.Count > 0)
            {

                foreach (var pair in pairs)
                {
                    bool isMirrored = false;
                    char[] delimeters = new char[] { '#', '@' };
                    string[] pairsCheck = pair.Split(delimeters, StringSplitOptions.RemoveEmptyEntries);
                    string firstWord = pairsCheck[0];
                    string secondWord = pairsCheck[1];
                    secondWord = Reverse(secondWord);
                    if (firstWord == secondWord)
                    {
                        isMirrored = true;
                    }

                    if (isMirrored)
                    {
                        if (!mirroredPairs.ContainsKey(pairsCheck[0]))
                        {
                            mirroredPairs[pairsCheck[0]] = pairsCheck[1];
                        }
                    }
                }
                Console.WriteLine($"{pairs.Count} word pairs found!");
            }
            else
            {
                Console.WriteLine("No word pairs found!");
            }
            if (mirroredPairs.Count > 0)
            {
                string result = string.Empty;
                List<string> resultOfMirroredString = new List<string>();
                Console.WriteLine("The mirror words are:");
                foreach (var mirroredPair in mirroredPairs)
                {
                    //Console.Write($"{mirroredPair.Key} <=> {mirroredPair.Value}, ");

                    result = string.Join(" <=> ", mirroredPair.Key, mirroredPair.Value);
                    resultOfMirroredString.Add(result);
                }

                Console.WriteLine(string.Join(", ", resultOfMirroredString));
            }
            else
            {
                Console.WriteLine("No mirror words!");
            }


        }

        static string Reverse(string secondWord)
        {
            char[] array = secondWord.ToCharArray();
            Array.Reverse(array);
            return new String(array);
        }
    }
}
