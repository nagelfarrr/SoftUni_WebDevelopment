using System;
using System.Text.RegularExpressions;

namespace _06.ExtractEmails
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            string emailPattern = @"(^|(?<=\s))(([a-zA-Z0-9]+)([\.\-_]?)([A-Za-z0-9]+)(@)([a-zA-Z]+([\.\-_][A-Za-z]+)+))(\b|(?=\s))";

            MatchCollection emails = Regex.Matches(input, emailPattern);

            foreach (Match email in emails)
            {
                if (email.Success)
                {
                    Console.WriteLine($"{email.Value}");
                }
            }
        }
    }
}
