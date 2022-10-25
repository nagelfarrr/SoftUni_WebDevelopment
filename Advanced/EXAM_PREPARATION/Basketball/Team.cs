using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace Basketball
{
    public class Team
    {

        public Team(string name, int openPositions, char group)
        {
            this.Name = name;
            this.OpenPositions = openPositions;
            this.Group = group;
            this.Players = new List<Player>();
        }

        public List<Player> Players { get; set; }
        public string Name { get; set; }
        public int OpenPositions { get; set; }
        public char Group { get; set; }

        public int Count
        {
            get { return this.Players.Count; }
        }


        public string AddPlayer(Player player)
        {
            if (string.IsNullOrEmpty(player.Name) || string.IsNullOrEmpty(player.Position))
                return $"Invalid player's information.";
            else if (this.OpenPositions == 0)
                return $"There are no more open positions.";
            else if (player.Rating < 80)
                return $"Invalid player's rating";
            else
            {
                this.Players.Add(player);
                this.OpenPositions--;
                return $"Successfully added {player.Name} to the team. Remaining open positions: {this.OpenPositions}.";
            }
        }

        public bool RemovePlayer(string name)
        {
            var targetPlayer = this.Players.FirstOrDefault(x => x.Name == name);
            if (targetPlayer == null)
            {
                return false;
            }
            this.OpenPositions++;
            this.Players.Remove(targetPlayer);
            return true;
        }

        public int RemovePlayerByPosition(string position)
        {
            int removedPlayers = 0;
            while (this.Players.FirstOrDefault(p => p.Position == position) != null)
            {
                var targetPlayer = this.Players.FirstOrDefault(p => p.Position == position);
                this.OpenPositions++;
                this.Players.Remove(targetPlayer);
                removedPlayers++;
            }

            return removedPlayers;
        }

        public Player RetirePlayer(string name)
        {
            var retiredPlayer = this.Players.FirstOrDefault(p => p.Name == name);
            if (retiredPlayer == null)
                return null;
            retiredPlayer.Retired = true;
            return retiredPlayer;

        }

        public List<Player> AwardPlayers(int games)
        {
            return this.Players.Where(p => p.Games >= games).ToList();
        }

        public string Report()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Active players competing for Team {this.Name} from Group {this.Group}");

            var nonRetiredPlayers = this.Players.Where(p => p.Retired == false).ToList();
            foreach (var player in nonRetiredPlayers)
            {
                sb.AppendLine(player.ToString());
            }

            return sb.ToString().TrimEnd();
        }
    }
}
