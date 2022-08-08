using System;
using System.Text.RegularExpressions;

namespace SecondTask
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int numberOfInputs = int.Parse(Console.ReadLine());

            string pattern = @"\|(?<boss>[A-Z]{4,})\|:\#(?<title>[A-Za-z]+\s[A-Za-z]+)\#";
            Regex regex = new Regex(pattern);

            for (int i = 0; i < numberOfInputs; i++)
            {
                string input = Console.ReadLine();

                Match match = regex.Match(input);

                if (match.Success)
                {
                    string bossName = match.Groups["boss"].Value;
                    string title = match.Groups["title"].Value;

                    Console.WriteLine($"{bossName}, The {title}\n>> Strength: {bossName.Length}\n>> Armor: {title.Length}");
                }
                else
                {
                    Console.WriteLine("Access denied!");
                }
            }
        }
    }
}
