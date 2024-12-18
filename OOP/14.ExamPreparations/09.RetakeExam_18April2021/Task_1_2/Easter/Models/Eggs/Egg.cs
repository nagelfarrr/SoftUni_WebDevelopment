﻿namespace Easter.Models.Eggs
{
    using System;
    using Easter.Models.Eggs.Contracts;
    using Easter.Utilities.Messages;

    public class Egg : IEgg
    {
        private string name;
        private int energyRequired;

        public Egg(string name, int energyRequired)
        {
            this.Name = name;
            this.EnergyRequired = energyRequired;
        }

        public string Name
        {
            get => this.name;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.InvalidEggName);
                }

                this.name = value;
            }
        }
        public int EnergyRequired
        {
            get => this.energyRequired;
            private set
            {
                if (value < 0)
                {
                    this.energyRequired = 0;
                }
                else
                    this.energyRequired = value;
            }
        }
        public void GetColored()
        {
            this.EnergyRequired -= 10;
        }

        public bool IsDone() => this.EnergyRequired == 0;

    }
}
