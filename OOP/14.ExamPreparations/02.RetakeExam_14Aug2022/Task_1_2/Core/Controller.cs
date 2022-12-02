namespace PlanetWars.Core
{
    using System;
    using System.Linq;
    using System.Text;
    using PlanetWars.Core.Contracts;
    using PlanetWars.IO;
    using PlanetWars.Models.MilitaryUnits;
    using PlanetWars.Models.MilitaryUnits.Contracts;
    using PlanetWars.Models.Planets;
    using PlanetWars.Models.Planets.Contracts;
    using PlanetWars.Models.Weapons;
    using PlanetWars.Models.Weapons.Contracts;
    using PlanetWars.Repositories;
    using PlanetWars.Repositories.Contracts;
    using PlanetWars.Utilities.Messages;

    public class Controller : IController
    {
        private IRepository<IPlanet> planets;


        public Controller()
        {
            this.planets = new PlanetRepository();

        }

        public string CreatePlanet(string name, double budget)
        {
            if (planets.Models.Any(p => p.Name == name))
            {
                return string.Format(OutputMessages.ExistingPlanet, name);
            }
            else
            {
                IPlanet planet = new Planet(name, budget);

                planets.AddItem(planet);
                return string.Format(OutputMessages.NewPlanet, name);
            }
        }

        public string AddUnit(string unitTypeName, string planetName)
        {
            if (!planets.Models.Any(p => p.Name == planetName))
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.UnexistingPlanet, planetName));
            }

            string[] unitNames = new string[] { "AnonymousImpactUnit", "SpaceForces", "StormTroopers" };
            if (!unitNames.Contains(unitTypeName))
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.ItemNotAvailable, unitTypeName));
            }

            var planet = this.planets.FindByName(planetName);

            if (planet.Army.Any(u => u.GetType().Name == unitTypeName))
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.UnitAlreadyAdded, unitTypeName, planetName));
            }

            IMilitaryUnit militaryUnit = null;
            switch (unitTypeName)
            {
                case "AnonymousImpactUnit":
                    militaryUnit = new AnonymousImpactUnit();
                    break;
                case "SpaceForces":
                    militaryUnit = new SpaceForces();
                    break;
                case "StormTroopers":
                    militaryUnit = new StormTroopers();
                    break;
            }

            planet.Spend(militaryUnit.Cost);
            planet.AddUnit(militaryUnit);

            return string.Format(OutputMessages.UnitAdded, unitTypeName, planetName);

        }

        public string AddWeapon(string planetName, string weaponTypeName, int destructionLevel)
        {
            if (!planets.Models.Any(p => p.Name == planetName))
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.UnexistingPlanet, planetName));
            }

            var planet = this.planets.FindByName(planetName);

            if (planet.Weapons.Any(w => w.GetType().Name == weaponTypeName))
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.WeaponAlreadyAdded, weaponTypeName,
                    planetName));
            }

            string[] weaponNames = new string[] { "BioChemicalWeapon", "NuclearWeapon", "SpaceMissiles" };
            if (!weaponNames.Contains(weaponTypeName))
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.ItemNotAvailable, weaponTypeName));
            }
            
            IWeapon weapon = null;
            switch (weaponTypeName)
            {
                case "BioChemicalWeapon":
                    weapon = new BioChemicalWeapon(destructionLevel);
                    break;
                case "NuclearWeapon":
                    weapon = new NuclearWeapon(destructionLevel);
                    break;
                case "SpaceMissiles":
                    weapon = new SpaceMissiles(destructionLevel);
                    break;
            }

            planet.Spend(weapon.Price);
            planet.AddWeapon(weapon);

            return string.Format(OutputMessages.WeaponAdded, planetName, weaponTypeName);
        }

        public string SpecializeForces(string planetName)
        {
            if (!planets.Models.Any(p => p.Name == planetName))
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.UnexistingPlanet, planetName));
            }

            var planet = this.planets.FindByName(planetName);

            if (!planet.Army.Any())
            {
                throw new InvalidOperationException(ExceptionMessages.NoUnitsFound);
            }


            planet.Spend(1.25);
            planet.TrainArmy();

            return string.Format(OutputMessages.ForcesUpgraded, planetName);
        }

        public string SpaceCombat(string planetOne, string planetTwo)
        {
            IPlanet firstPlanet = planets.FindByName(planetOne);
            IPlanet secondPlanet = planets.FindByName(planetTwo);
            string winner = "none";
            if (firstPlanet.MilitaryPower > secondPlanet.MilitaryPower)
                winner = "first";
            else if (firstPlanet.MilitaryPower < secondPlanet.MilitaryPower)
                winner = "second";

            if (winner == "none")
            {
                bool firstHasNuclear = firstPlanet.Weapons.Any(x => x.GetType().Name == "NuclearWeapon");
                bool secondHasNuclear = secondPlanet.Weapons.Any(x => x.GetType().Name == "NuclearWeapon");

                if (firstHasNuclear && !secondHasNuclear)
                {
                    winner = "first";
                }
                else if (!firstHasNuclear && secondHasNuclear)
                {
                    winner = "second";
                }
            }
            string output = string.Empty;
            switch (winner)
            {
                case "first":
                    output = CombatAftermath(firstPlanet, secondPlanet); break;
                case "second":
                    output = CombatAftermath(secondPlanet, firstPlanet); break;
                case "none":
                    firstPlanet.Spend(firstPlanet.Budget / 2);
                    secondPlanet.Spend(secondPlanet.Budget / 2);
                    output = OutputMessages.NoWinner;
                    break;
            }
            return output;
        }

        private string CombatAftermath(IPlanet winner, IPlanet loser)
        {
            double salvageProfit = loser.Army.Sum(x => x.Cost) +
                                   loser.Weapons.Sum(x => x.Price);

            winner.Spend(winner.Budget / 2);
            winner.Profit(loser.Budget / 2);
            winner.Profit(salvageProfit);
            planets.RemoveItem(loser.Name);
            return String.Format(OutputMessages.WinnigTheWar, winner.Name, loser.Name);
        }

        public string ForcesReport()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("***UNIVERSE PLANET MILITARY REPORT***");

            foreach (var planet in planets.Models.OrderByDescending(p => p.MilitaryPower).ThenBy(p => p.Name))
            {
                sb.AppendLine(planet.PlanetInfo());
            }

            return sb.ToString().TrimEnd();
        }


    }
}
