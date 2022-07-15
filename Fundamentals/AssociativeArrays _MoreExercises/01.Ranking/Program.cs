using System;
using System.Collections.Generic;
using System.Linq;

namespace _01.Ranking
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, string> contestPasswords = new Dictionary<string, string>();

            while (true)
            {
                string input = Console.ReadLine();
                if (input == "end of contests") break;
                string[] contests = input.Split(':');
                string contestName = contests[0];
                string contestPassword = contests[1];

                if (!contestPasswords.ContainsKey(contestName)) contestPasswords[contestName] = string.Empty;
                contestPasswords[contestName] = contestPassword;
            }

            SortedDictionary<string, Dictionary<string, int>> userPoints = new SortedDictionary<string, Dictionary<string, int>>();

            while (true)
            {
                string input = Console.ReadLine();
                if (input == "end of submissions") break;
                string[] commands = input.Split("=>");
                string contestName = commands[0];
                string contestPassword = commands[1];
                string userName = commands[2];
                int points = int.Parse(commands[3]);


                foreach (var contest in contestPasswords)
                {
                    if (contest.Key == contestName && contest.Value == contestPassword)
                    {
                        if (!userPoints.ContainsKey(userName)) 
                            userPoints[userName] = new Dictionary<string, int>();

                        userPoints[userName].TryAdd(contestName, points);

                        if (userPoints[userName].ContainsKey(contestName))
                        {
                            if (userPoints[userName][contestName] < points)
                                userPoints[userName][contestName] = points;
                        }
                        else
                            userPoints[userName].Add(contestName,points);
                    }
                }
            }

            Dictionary<string, int> userTotalPoints = new Dictionary<string, int>();
            foreach (var user in userPoints)
            {
                userTotalPoints[user.Key] = user.Value.Values.Sum();
            }

            string bestUser = userTotalPoints.Keys.Max();
            int bestPoints = userTotalPoints.Values.Max();
            Console.WriteLine($"Best candidate is {bestUser} with total {bestPoints} points.");
            
            Console.WriteLine("Ranking: ");
           
            foreach (var user in userPoints)
            {

                Console.WriteLine($"{user.Key}");
                foreach (var contest in user.Value.OrderByDescending(u => u.Value))
                {
                    Console.WriteLine($"#  {contest.Key} -> {contest.Value}");

                }
            }
        }
    }
}
