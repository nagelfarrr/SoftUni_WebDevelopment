using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;

namespace _02.Judge
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, Dictionary<string, int>> contestUserPoints = new Dictionary<string, Dictionary<string, int>>();
            Dictionary<string, int> totalUserPoints = new Dictionary<string, int>();
            while (true)
            {
                string input = Console.ReadLine();
                if (input == "no more time") break;
                string[] tokens = input.Split(" -> ");
                string userName = tokens[0];
                string contestName = tokens[1];
                int points = int.Parse(tokens[2]);

                if (!contestUserPoints.ContainsKey(contestName))
                {
                    contestUserPoints.Add(contestName, new Dictionary<string, int>());
                    contestUserPoints[contestName][userName] = points;
                }

                else
                {
                    if (!contestUserPoints[contestName].ContainsKey(userName))
                    {
                        contestUserPoints[contestName][userName] = points;
                    }
                    else
                    {
                        if (contestUserPoints[contestName][userName] <= points)
                            contestUserPoints[contestName][userName] = points;
                    }
                }


            }


            foreach (var contest in contestUserPoints)
            {
                int counterPosition = 0;
                Console.WriteLine($"{contest.Key}: {contest.Value.Count} participants");

                foreach (var user in contest.Value.OrderByDescending(c => c.Value).ThenBy(c=> c.Key))
                {
                    counterPosition++;
                    Console.WriteLine($"{counterPosition}. {user.Key} <::> {user.Value}");
                    
                }
            }


            Console.WriteLine("Individual standings:");
            foreach (var contest in contestUserPoints)
            {
                foreach (var name in contest.Value)
                {
                    if (!totalUserPoints.ContainsKey(name.Key))
                        totalUserPoints[name.Key] = name.Value;

                    else
                        totalUserPoints[name.Key] += name.Value;

                }

            }

            int positionCounter = 0;
            foreach (var user in totalUserPoints.OrderByDescending(u => u.Value).ThenBy(u => u.Key))
            {
                positionCounter++;
                Console.WriteLine($"{positionCounter}. {user.Key} -> {user.Value}");
            }
        }
    }
}
