using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace _02.AdAstra
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            string pattern = @"([#\|])(?<item>[A-Za-z\s]+)\1(?<date>[0-9]{2}/[0-9]{2}/[0-9]{2})*\1(?<calories>[0-9]+)\1";

            const int KCALPERDAY = 2000;
            int totalCalories = 0;

            MatchCollection matches = Regex.Matches(input, pattern);

            foreach (Match match in matches)
            {
                totalCalories += int.Parse(match.Groups["calories"].Value);
            }


            int daysToSurvive = totalCalories / KCALPERDAY;


            PrintFoodInformation(daysToSurvive, matches);
        }

        static void PrintFoodInformation(int daysToSurvive, MatchCollection matches)
        {
            Console.WriteLine($"You have food to last you for: {daysToSurvive} days!");

            foreach (Match match in matches)
            {
                Console.WriteLine(
                    $"Item: {match.Groups["item"].Value}, Best before: {match.Groups["date"].Value}, Nutrition: {match.Groups["calories"].Value}");
            }
        }
    }


}
