using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace DestinationMapper
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            string pattern = @"([=\/])(?<location>[A-Z]{1}[A-Za-z]{2,})\1";

            List<string> locations = new List<string>();

            MatchCollection matches = Regex.Matches(input, pattern);

            foreach (Match match in matches)
            {
                string validLocation = match.Groups["location"].Value;
                locations.Add(validLocation);
            }

            int travelPoints = 0;

            foreach (var location in locations)
            {
                travelPoints += location.Length;
            }

            Console.WriteLine($"Destinations: " + string.Join(", ", locations));
            Console.WriteLine($"Travel Points: {travelPoints}");
        }
    }
}
