using System;
using System.Collections.Generic;
using System.Linq;


namespace _05.FootballTeamGenerator
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            List<Team> teams = new List<Team>();

            while (true)
            {
                try
                {
                    string input = Console.ReadLine();
                    if (input == "END") break;

                    string[] commands = input.Split(';');

                    switch (commands[0])
                    {
                        case "Team":
                            teams.Add(new Team(commands[1]));
                            break;

                        case "Add":
                            var player = new Player(commands[2],
                                new Stats(int.Parse(commands[3]), int.Parse(commands[4]), int.Parse(commands[5]),
                                    int.Parse(commands[6]), int.Parse(commands[7])));

                            var teamToAdd = FindTeam(teams, commands[1]);
                            teamToAdd.AddPlayer(player);
                            break;

                        case "Remove":
                            var teamToRemove = FindTeam(teams, commands[1]);
                            teamToRemove.RemovePlayer(commands[2]);

                            break;

                        case "Rating":
                            var teamRating = FindTeam(teams, commands[1]);

                            Console.WriteLine($"{teamRating.Name} - {teamRating.Rating}");

                            break;
                    }


                }
                catch (ArgumentException ae)
                {
                    Console.WriteLine(ae.Message);

                }
            }
        }

        static Team FindTeam(List<Team> teams, string teamName)
        {
            if (teams.All(t => t.Name != teamName))
                throw new ArgumentException(string.Format(ExceptionMessages.MissingTeam, teamName));

            return teams.Find(t => t.Name == teamName);
        }
    }
}
