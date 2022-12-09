namespace Easter.Models.Bunnies
{
    using System;
    using System.Collections.Generic;
    using Easter.Models.Bunnies.Contracts;
    using Easter.Models.Dyes.Contracts;
    using Easter.Utilities.Messages;

    public abstract class Bunny : IBunny
    {
        private string name;
        private int energy;
        private List<IDye> dyes;

        public Bunny(string name, int energy)
        {
            this.Name = name;
            this.Energy = energy;

            this.dyes = new List<IDye>();
        }

        public string Name
        {
            get => this.name;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.InvalidBunnyName);
                }

                this.name = value;
            }
        }
        public int Energy
        {
            get => this.energy;
            protected set
            {
                if (value < 0)
                {
                    this.energy = 0;
                }
                else
                    this.energy = value;
            }
        }
        public ICollection<IDye> Dyes
        {
            get => this.dyes;
        }

        public abstract void Work();


        public virtual void AddDye(IDye dye)
        {
            this.dyes.Add(dye);
        }
    }
}
