using System;
using System.Collections.Generic;
using System.Text;

namespace PlanetWars.Models.Planets
{
    using System.Linq;
    using PlanetWars.Models.MilitaryUnits.Contracts;
    using PlanetWars.Models.Planets.Contracts;
    using PlanetWars.Models.Weapons;
    using PlanetWars.Models.Weapons.Contracts;
    using PlanetWars.Repositories;
    using PlanetWars.Utilities.Messages;

    public class Planet : IPlanet
    {
        private UnitRepository units;
        private WeaponRepository weapons;

        private string name;
        private double budget;
       
        public Planet(string name, double budget)
        {
            units = new UnitRepository();
            weapons = new WeaponRepository();
            
            this.Name = name;
            this.Budget = budget;
        }

        public string Name
        {
            get => this.name;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.InvalidPlanetName);
                }
                this.name = value;
            }
        }

        public double Budget
        {
            get => this.budget;
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException(ExceptionMessages.InvalidBudgetAmount);
                }

                this.budget = value;
            }
        }

        public double MilitaryPower
        {
            get => MilitaryTotalPower();

        }

        public IReadOnlyCollection<IMilitaryUnit> Army
        {
            get => units.Models;

        }
        public IReadOnlyCollection<IWeapon> Weapons
        {
            get => weapons.Models;
        }
        public void AddUnit(IMilitaryUnit unit)
        {
            units.AddItem(unit);
        }

        public void AddWeapon(IWeapon weapon)
        {
            weapons.AddItem(weapon);
        }

        public void TrainArmy()
        {
            foreach (var unit in this.Army)
            {
                unit.IncreaseEndurance();
            }
        }

        public void Spend(double amount)
        {
            if (this.Budget < amount) // budget-amount < 0 ???
            {
                throw new InvalidOperationException(ExceptionMessages.UnsufficientBudget);
            }
            this.Budget -= amount;
        }

        public void Profit(double amount)
        {
            this.Budget += amount;
        }

        public string PlanetInfo()
        {
            StringBuilder sb = new StringBuilder();

          
            sb.AppendLine($"Planet: {Name}");

            sb.AppendLine($"--Budget: {Budget} billion QUID");

            sb.AppendLine(units.Models.Any()
                ? $"--Forces: {string.Join(", ", units.Models.Select(x => x.GetType().Name))}"
                : "--Forces: No units");

            sb.AppendLine(weapons.Models.Any()
                ? $"--Combat equipment: {string.Join(", ", weapons.Models.Select(x => x.GetType().Name))}"
                : "--Combat equipment: No weapons");

            sb.Append($"--Military Power: {MilitaryPower}");

            return sb.ToString().TrimEnd();

        }

        private double MilitaryTotalPower()
        {
            double totalAmount = this.Army.Select(u => u.EnduranceLevel).Sum() +
                                 this.Weapons.Select(w => w.DestructionLevel).Sum();

            if (this.Army.Any(u => u.GetType().Name == "AnonymousImpactUnit"))
                totalAmount *= 1.30;
            if (this.Weapons.Any(w => w.GetType().Name == "NuclearWeapon"))
                totalAmount *= 1.45;

            return Math.Round(totalAmount, 3);

        }
    }
}
