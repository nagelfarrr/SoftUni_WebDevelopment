namespace SpaceStation.Models.Mission
{
    using System.Collections.Generic;
    using System.Linq;
    using SpaceStation.Models.Astronauts.Contracts;
    using SpaceStation.Models.Mission.Contracts;
    using SpaceStation.Models.Planets.Contracts;

    public class Mission : IMission
    {
        public void Explore(IPlanet planet, ICollection<IAstronaut> astronauts)
        {
            Queue<IAstronaut> astronautsQueue = new Queue<IAstronaut>(astronauts);

            while (astronautsQueue.Any() && planet.Items.Any())
            {
                if (astronautsQueue.Peek().CanBreath == false)
                {
                    astronautsQueue.Dequeue();
                }
                var astronautToExplore = astronautsQueue.Dequeue();

                while (astronautToExplore.CanBreath)
                {
                    var item = planet.Items.First();

                    astronautToExplore.Bag.Items.Add(item);
                    astronautToExplore.Breath();

                    planet.Items.Remove(item);

                    if (planet.Items.Count == 0)
                    {
                        break;
                    }
                }

            }
        }
    }
}
