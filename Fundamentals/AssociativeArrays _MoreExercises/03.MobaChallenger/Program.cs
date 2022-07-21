using System;
using System.Collections.Generic;
using System.Linq;

namespace _03.MobaChallenger
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, Dictionary<string, int>> playersInfo = new Dictionary<string, Dictionary<string, int>>();

            string input = Console.ReadLine();


            while (input != "Season end")
            {

                string[] commands = input.Split(new string[] { " -> ", " vs " }, StringSplitOptions.RemoveEmptyEntries);
                if (commands.Length > 2)
                {
                    string playerName = commands[0];
                    string playerPosition = commands[1];
                    int playerSkillPoints = int.Parse(commands[2]);

                    if (!playersInfo.ContainsKey(playerName))
                    {
                        playersInfo[playerName] = new Dictionary<string, int>();
                    }
                    playersInfo[playerName].TryAdd(playerPosition, playerSkillPoints);

                    if (playersInfo[playerName][playerPosition] < playerSkillPoints)
                        playersInfo[playerName][playerPosition] = playerSkillPoints;
                }
                else
                {
                    string playerOne = commands[0];
                    string playerTwo = commands[1];

                    if (playersInfo.ContainsKey(playerOne) && playersInfo.ContainsKey(playerTwo))
                    {

                        foreach (var firstPlayer in playersInfo[playerOne])
                        {
                            foreach (var secondPlayer in playersInfo[playerTwo])
                            {
                                if (firstPlayer.Key == secondPlayer.Key)
                                {
                                    if (firstPlayer.Value > secondPlayer.Value)
                                    {
                                        playersInfo.Remove(playerTwo);
                                    }
                                    else
                                    {
                                        playersInfo.Remove(playerOne);
                                    }
                                }
                            }
                        }

                    }
                }

                input = Console.ReadLine();
            }

            //foreach (var playerInfo in playersInfo)
            //{
            //    Dictionary<string, int> finalRankings = new Dictionary<string, int>();

            //    foreach (var player in playersInfo)
            //    {
            //        finalRankings[player.Key] = player.Value.Values.Sum();
            //    }

            //    var bestPlayerTotalPoints = finalRankings.Values.Max();
            //    var bestPlayerName = finalRankings.OrderByDescending(x => x.Value).FirstOrDefault().Key;

            //    Console.WriteLine($"{bestPlayerName}: {bestPlayerTotalPoints} skill");

            //}   TO DO

        }
    }


}
