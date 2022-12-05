namespace NavalVessels.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using NavalVessels.Models.Contracts;
    using NavalVessels.Utilities.Messages;

    public class Captain : ICaptain
    {
        private string fullName;
        private List<IVessel> vessels;
        private int combatExperience;

        public Captain(string fullName)
        {
            this.FullName = fullName;

            this.vessels = new List<IVessel>();
            this.CombatExperience = 0;
        }

        public string FullName
        {
            get => this.fullName;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException(ExceptionMessages.InvalidCaptainName);
                }
                this.fullName = value;
            }
        }
        public int CombatExperience
        {
            get => this.combatExperience;
            private set => this.combatExperience = value;
        }

        public ICollection<IVessel> Vessels => this.vessels.AsReadOnly();
      

        public void AddVessel(IVessel vessel)
        {
            if (vessel == null)
            {
                throw new NullReferenceException(ExceptionMessages.InvalidVesselForCaptain);
            }

            this.vessels.Add(vessel);
        }

        public void IncreaseCombatExperience()
        {
            this.CombatExperience += 10;
        }

        public string Report()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(
                $"{this.FullName} has {this.CombatExperience} combat experience and commands {this.Vessels.Count} vessels.");

            if (this.Vessels.Any())
            {
                foreach (var vessel in this.vessels)
                {
                    sb.AppendLine();
                    sb.AppendLine(vessel.ToString());
                }
            }

            return sb.ToString().Trim();
        }
    }
}
