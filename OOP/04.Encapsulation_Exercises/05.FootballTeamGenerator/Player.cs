using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace _05.FootballTeamGenerator
{
    public class Player
    {
        private string name;
       
        public Player(string name, Stats stats)
        {
            this.Name = name;
            this.Stats = stats;
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

        public Stats Stats { get;  set; }

        public int OverallSkill =>
            (int)Math.Round((double)(this.Stats.Endurance + this.Stats.Sprint + this.Stats.Dribble +
                                     this.Stats.Passing + this.Stats.Shooting) / 5.0d);
    }
}
