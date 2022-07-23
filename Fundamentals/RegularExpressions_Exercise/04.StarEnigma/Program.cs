using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace _04.StarEnigma
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int numberOfInputs = int.Parse(Console.ReadLine());

            string encryptedPattern = @"[SsTtAaRr]";
            string decryptedPattern = @"@(?<name>[A-Za-z]+)[^@:!\->]*:(?<population>\d+)[^@:!\->]*!(?<type>[AD])![^@:!\->]*->(?<count>\d+)";

            List<string> attackedPlanets = new List<string>();
            List<string> destroyedPlanets = new List<string>();

            for (int i = 0; i < numberOfInputs; i++)
            {
                string encryptedMessage = Console.ReadLine();
                string decryptedMessage = string.Empty;
                MatchCollection matches = Regex.Matches(encryptedMessage, encryptedPattern);
                int count = matches.Count;

                foreach (var chr in encryptedMessage)
                {
                    decryptedMessage += (char)(chr - count);
                }

                Match match = Regex.Match(decryptedMessage, decryptedPattern);
                if (match.Success)
                {
                    string planetName = match.Groups["name"].Value;
                    //int population = int.Parse(match.Groups["population"].Value);
                    string attackType = match.Groups["type"].Value;
                    //int soldiersCount = int.Parse(match.Groups[count].Value);

                    if (attackType == "A")
                    {
                        if (!attackedPlanets.Contains(planetName))
                        {
                            attackedPlanets.Add(planetName);
                        }
                    }
                    else if (attackType == "D")
                    {
                        if (!attackedPlanets.Contains(planetName))
                        {
                            destroyedPlanets.Add(planetName);
                        }
                    }
                }
            }

            attackedPlanets.Sort();
            destroyedPlanets.Sort();
            Console.WriteLine($"Attacked planets: {attackedPlanets.Count}");
            foreach (var planet in attackedPlanets)
            {
                Console.WriteLine($"-> {planet}");
            }
            Console.WriteLine($"Destroyed planets: {destroyedPlanets.Count}");
            foreach (var planet in destroyedPlanets)
            {
                Console.WriteLine($"-> {planet}");
            }
        }
    }
}
