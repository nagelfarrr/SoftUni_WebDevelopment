﻿namespace _07.MilitaryElite.Models
{
    using Contracts;

    public class SpecialisedSoldier : Private, ISpecialisedSoldier
    {
        private string corps;
        public SpecialisedSoldier(string id, string firstName, string lastName, decimal salary, string corps) : base(id, firstName, lastName, salary)
        {
            this.Corps = corps;
        }

        public string Corps
        {
            get => this.corps;

           private set
            {
                if (value == "Airforces" || value == "Marines")
                {
                    this.corps = value;
                }
            }
        }
    }
}
