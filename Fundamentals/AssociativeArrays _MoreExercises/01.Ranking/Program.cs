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
                string[] tokens = input.Split(':');
                string contestName = tokens[0];
                string contestPassword = tokens[1];

                if (!contestPasswords.ContainsKey(contestName))
                {
                    contestPasswords[contestName] = string.Empty;
                }
                contestPasswords[contestName] = contestPassword;
            }
            Dictionary<string, List<int>> userPoints = new Dictionary<string, List<int>>();
            SortedDictionary<string, Dictionary<string, List<int>>> pointsByContest = new SortedDictionary<string, Dictionary<string, List<int>>>();
            while (true)
            {
                string input = Console.ReadLine();
                if (input == "end of submissions") break;
                string[] tokens = input.Split("=>");
                string contestName = tokens[0];
                string password = tokens[1];
                string username = tokens[2];
                int points = int.Parse(tokens[3]);

                foreach (var passwordCheck in contestPasswords)
                {
                    if (contestName == passwordCheck.Key && password == passwordCheck.Value)
                    {
                        if (!userPoints.ContainsKey(username)) userPoints[username] = new List<int>();
                        userPoints[username].Add(points);

                        if (!pointsByContest.ContainsKey(contestName)) pointsByContest[contestName] = new Dictionary<string, List<int>>();
                        pointsByContest[contestName].Add();
                    }
                }

            }

            string bestUser = userPoints.Keys.First();
            ;
            Console.WriteLine($"Best candidate is {bestUser} with total {userPoints[bestUser].Sum()} points.");

            foreach (var name in pointsByContest)
            {
                Console.WriteLine($"{name.Value.Keys.First()}");
            }
        }
    }
}
