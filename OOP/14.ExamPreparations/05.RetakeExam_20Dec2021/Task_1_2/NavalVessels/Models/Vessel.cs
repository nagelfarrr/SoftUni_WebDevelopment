
namespace NavalVessels.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using Contracts;
    using NavalVessels.Utilities.Messages;

    public abstract class Vessel : IVessel
    {
        private string name;
        private ICaptain captain;
        private ICollection<string> targets;
        private double mainWeaponCaliber;
        private double speed;
        private double armorThickness;

        protected Vessel(string name, double mainWeaponCaliber, double speed, double armorThickness)
        {
            this.Name = name;
            this.MainWeaponCaliber = mainWeaponCaliber;
            this.Speed = speed;
            this.ArmorThickness = armorThickness;

            this.targets = new List<string>();
        }

        public string Name
        {
            get => this.name;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException(ExceptionMessages.InvalidVesselName);
                }
                this.name = value;
            }
        }

        public ICaptain Captain
        {
            get => this.captain;
            set
            {
                if (value == null)
                {
                    throw new NullReferenceException(ExceptionMessages.InvalidCaptainToVessel);
                }

                this.captain = value;
            }
        }

        public double ArmorThickness
        {
            get => this.armorThickness;
            set
            {
                if (value < 0)
                    this.armorThickness = 0;
                else
                {
                    this.armorThickness = value;
                }
            }
        }
        public double MainWeaponCaliber
        {
            get => this.mainWeaponCaliber;
            protected set => this.mainWeaponCaliber = value;
        }
        public double Speed
        {
            get => this.speed;
            protected set => this.speed = value;
        }
        public ICollection<string> Targets
        {
            get => this.targets;

        }

        public void Attack(IVessel target)
        {
            if (target == null)
            {
                throw new NullReferenceException(ExceptionMessages.InvalidTarget);
            }

            target.ArmorThickness -= this.MainWeaponCaliber;
            this.targets.Add(target.Name);
            
        }

        public virtual void RepairVessel(){}

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"- {this.Name}");
            sb.AppendLine($"*Type: {this.GetType().Name}");
            sb.AppendLine($"*Armor thickness: {this.ArmorThickness}");
            sb.AppendLine($"*Main weapon caliber: {this.MainWeaponCaliber}");
            sb.AppendLine($"*Speed: {this.Speed}");

            string targets;
            if (!this.Targets.Any())
            {
                targets = "None";
            }
            else
            {
                targets = string.Join(", ", this.Targets);
            }

            sb.AppendLine($"*Targets: {targets}");

            return sb.ToString().Trim();
        }
    }
}
