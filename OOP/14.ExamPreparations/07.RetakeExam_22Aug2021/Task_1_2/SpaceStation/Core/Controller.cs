namespace SpaceStation.Core
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection.Metadata;
    using System.Text;
    using SpaceStation.Core.Contracts;
    using SpaceStation.Models.Astronauts;
    using SpaceStation.Models.Astronauts.Contracts;
    using SpaceStation.Models.Mission;
    using SpaceStation.Models.Mission.Contracts;
    using SpaceStation.Models.Planets;
    using SpaceStation.Models.Planets.Contracts;
    using SpaceStation.Repositories;
    using SpaceStation.Repositories.Contracts;
    using SpaceStation.Utilities.Messages;

    public class Controller : IController
    {
        private IRepository<IAstronaut> astronauts;
        private IRepository<IPlanet> planets;
        private IMission mission;
        private int planetExporeCount = 0;
        public Controller()
        {
            astronauts = new AstronautRepository();
            planets = new PlanetRepository();
            mission = new Mission();
        }

        public string AddAstronaut(string type, string astronautName)
        {
            IAstronaut astronaut;
            switch (type)
            {
                case "Biologist":
                    astronaut = new Biologist(astronautName);
                    break;
                case "Geodesist":
                    astronaut = new Geodesist(astronautName);
                    break;
                case "Meteorologist":
                    astronaut = new Meteorologist(astronautName);
                    break;
                default:
                    throw new InvalidOperationException(ExceptionMessages.InvalidAstronautType);
            }

            astronauts.Add(astronaut);

            return string.Format(OutputMessages.AstronautAdded, type, astronautName);
        }

        public string AddPlanet(string planetName, params string[] items)
        {
            IPlanet planet = new Planet(planetName);

            foreach (var item in items)
            {
                planet.Items.Add(item);
            }

            planets.Add(planet);

            return string.Format(OutputMessages.PlanetAdded, planetName);
        }

        public string RetireAstronaut(string astronautName)
        {
            var astronaut = astronauts.FindByName(astronautName);

            if (astronaut == null)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.InvalidRetiredAstronaut,
                    astronautName));
            }

            astronauts.Remove(astronaut);

            return string.Format(OutputMessages.AstronautRetired, astronautName);
        }

        public string ExplorePlanet(string planetName)
        {


            var planet = planets.FindByName(planetName);

            ICollection<IAstronaut> astronautsForMission = new List<IAstronaut>();

            foreach (var astronaut in astronauts.Models)
            {
                if (astronaut.Oxygen > 60)
                {
                    astronautsForMission.Add(astronaut);
                }
            }

            if (!astronautsForMission.Any())
            {
                throw new InvalidOperationException(ExceptionMessages.InvalidAstronautCount);
            }

            mission.Explore(planet, astronautsForMission);

            var deadAstronauts = astronautsForMission.Where(a => !a.CanBreath).ToList();

            planetExporeCount++;
            return string.Format(OutputMessages.PlanetExplored, planetName, deadAstronauts.Count);
        }

        public string Report()
        {
            StringBuilder sb = new StringBuilder();

            //string hasItems = astronauts.Models.Any(a => a.Bag.Items.Any())
            //    ? string.Join(", ", astronauts.Models.Select(a => a.Bag.Items))
            //    : "none";

            sb.AppendLine($"{planetExporeCount} planets were explored!");
            sb.AppendLine("Astronauts info:");

            foreach (var astronaut in astronauts.Models)
            {
                sb.AppendLine($"Name: {astronaut.Name}");
                sb.AppendLine($"Oxygen: {astronaut.Oxygen}");
                string hasItems = astronaut.Bag.Items.Any() ? string.Join(", ", astronaut.Bag.Items) : "none";
                sb.AppendLine($"Bag items: {hasItems}");
            }

            return sb.ToString().TrimEnd();
        }
    }
}
