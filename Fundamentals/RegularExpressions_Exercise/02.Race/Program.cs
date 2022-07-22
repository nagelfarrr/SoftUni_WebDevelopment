using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace _02.Race
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] participants = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries);

            string namePatern = @"[A-Za-z]";
            string digitPatern = @"[0-9]";

            Dictionary<string, int> racerKilometers = new Dictionary<string, int>();

            Regex namePattern = new Regex(namePatern);
            Regex digitPattern = new Regex(digitPatern);

            string input = Console.ReadLine();

            while (input != "end of race")
            {
                MatchCollection nameChars = namePattern.Matches(input);
                MatchCollection digitChars = digitPattern.Matches(input);
                string name = String.Empty;
                string digit = String.Empty;
                foreach (Match nameChar in nameChars)
                {
                    name += nameChar;
                }

                for (int i = 0; i < digitChars.Count; i++)
                {
                    digit += digitChars[i].Value;
                }

                int digitInInt = int.Parse(digit);
                int totalKilometers = 0;
                while (digitInInt > 0)
                {
                    int temp = digitInInt % 10;
                    totalKilometers += temp;
                    digitInInt = digitInInt / 10;
                }

                if (participants.Contains(name))
                {
                    if (!racerKilometers.ContainsKey(name))
                    {
                        racerKilometers[name] = totalKilometers;
                    }
                    else
                    {
                        racerKilometers[name] += totalKilometers;
                    }
                }

                input = Console.ReadLine();
            }

            int counter = 0;
            foreach (var racer in racerKilometers.OrderByDescending(x => x.Value))
            {
                counter++;
                if (counter == 1)
                {
                    Console.WriteLine($"{counter}st place: {racer.Key}");
                }
                else if (counter == 2)
                {
                    Console.WriteLine($"{counter}nd place: {racer.Key}");
                }
                else if(counter == 3)
                {
                    Console.WriteLine($"{counter}rd place: {racer.Key}");
                }
            }
        }
    }
}
