using System;
using System.Text.RegularExpressions;

namespace _03.MatchDates
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            string pattern = @"(?<day>[0-9]{2})(?<separator>[.\-/])(?<month>[A-Z][a-z]{2})\k<separator>(?<year>[0-9]{4})";

            MatchCollection matches = Regex.Matches(input, pattern);

            foreach (Match match in matches)
            {
                string day = match.Groups["day"].Value;
                string month = match.Groups["month"].Value;
                string year = match.Groups["year"].Value;

                Console.WriteLine($"Day: {day}, Month: {month}, Year: {year}");
            }
        }
    }
}
