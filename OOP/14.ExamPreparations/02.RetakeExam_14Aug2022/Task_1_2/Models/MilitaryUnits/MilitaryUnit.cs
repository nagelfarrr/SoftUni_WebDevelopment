namespace PlanetWars.Models.MilitaryUnits
{
    using System;
    using PlanetWars.Models.MilitaryUnits.Contracts;
    using PlanetWars.Utilities.Messages;

    public abstract class MilitaryUnit :IMilitaryUnit
    {
        public MilitaryUnit(double cost)
        {
            this.Cost = cost;
            this.EnduranceLevel = 1;
        }

        public double Cost { get; private set; }

        public int EnduranceLevel
        {
            get;
            private set;
        }
        public void IncreaseEndurance()
        {
            if (this.EnduranceLevel == 20)
            {
              
                throw new ArgumentException(ExceptionMessages.EnduranceLevelExceeded);
            }
            else
            this.EnduranceLevel++;
        }
    }
}
