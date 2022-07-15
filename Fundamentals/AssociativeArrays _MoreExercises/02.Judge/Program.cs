using System;
using System.Collections.Generic;
using System.ComponentModel.Design;

namespace _02.Judge
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, Dictionary<string, int>> contestUserPoints = new Dictionary<string, Dictionary<string, int>>();

            while (true)
            {
                string input = Console.ReadLine();
                if (input == "no more time") break;
                string[] tokens = input.Split(" -> ");
                string userName = tokens[0];
                string contestName = tokens[1];
                int points = int.Parse(tokens[2]);

                if (!contestUserPoints.ContainsKey(contestName)) contestUserPoints[contestName] = new Dictionary<string, int>();
                else
                {
                    if (!contestUserPoints[contestName].ContainsKey(userName))
                        contestUserPoints[contestName].Add(userName, points);
                    else
                        contestUserPoints[contestName][userName] = points;
                }


            }
        }
    }
}
