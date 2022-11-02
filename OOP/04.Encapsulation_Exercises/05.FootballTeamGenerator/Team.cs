using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _05.FootballTeamGenerator
{
    public class Team
    {
        private string name;
        private List<Player> players;

        public Team(string name)
        {
            this.Name = name;
            this.players = new List<Player>();
        }

        public string Name
        {
            get => this.name;
            set
            {
                if (string.IsNullOrEmpty(value) || string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException(string.Format(ExceptionMessages.EmptyName));

                this.name = value;
            }
        }

        public int Rating
        {
            get
            {
                if (this.players.Count > 0)
                    return (int)Math.Round(this.players.Select(p => p.OverallSkill).Average());
                else
                    return 0;
            }
        }


        public void AddPlayer(Player player)
        {
            this.players.Add(player);
        }

        public void RemovePlayer(string playerName)
        {
            if (!this.players.Any(p => p.Name == playerName))
                throw new ArgumentException(string.Format(ExceptionMessages.MissingPlayer, playerName, this.Name));
            
                this.players.Remove(this.players.Find(p => p.Name == playerName));
        }
    }
}
