using System;
using System.Collections.Generic;
using System.Text;

namespace _05.FootballTeamGenerator
{
    public class Stats
    {
        private int endurance;
        private int sprint;
        private int dribble;
        private int passing;
        private int shooting;

        public Stats(int endurance, int sprint, int dribble, int passing, int shooting)
        {
            this.Endurance = endurance;
            this.Sprint = sprint;
            this.Dribble = dribble;
            this.Passing = passing;
            this.Shooting = shooting;
        }

        public int Endurance
        {
            get => this.endurance;
            set
            {
                if (IsStatValid(nameof(this.Endurance), value))
                    this.endurance = value;
            }
        }

        public int Sprint
        {
            get => this.sprint;
            set
            {
                if (IsStatValid(nameof(this.Sprint), value))
                    this.sprint = value;
            }
        }

        public int Dribble
        {
            get => this.dribble;
            set
            {
                if (IsStatValid(nameof(this.Dribble), value))
                    this.dribble = value;
            }
        }

        public int Passing
        {
            get => this.passing;
            set
            {
                if (IsStatValid(nameof(this.Passing), value))
                    this.passing = value;
            }
        }

        public int Shooting
        {
            get => this.shooting;
            set
            {
                if (IsStatValid(nameof(this.Shooting), value))
                    this.shooting = value;
            }
        }


        private bool IsStatValid(string statName, int statValue)
        {
            if (statValue >= 0 && statValue <= 100)
                return true;
            else
                throw new ArgumentException(string.Format(ExceptionMessages.InvalidStatRange,statName));
        }
    }
}
