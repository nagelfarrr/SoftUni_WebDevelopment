using System;
using System.Collections.Generic;
using System.Text;

namespace PlanetWars.Repositories
{
    using System.Linq;
    using PlanetWars.Models.Planets.Contracts;
    using PlanetWars.Repositories.Contracts;

    public class PlanetRepository : IRepository<IPlanet>
    {
        private List<IPlanet> planets;

        public PlanetRepository()
        {
            planets = new List<IPlanet>();
        }

        public IReadOnlyCollection<IPlanet> Models => this.planets.AsReadOnly();
        public void AddItem(IPlanet model)
        {
            this.planets.Add(model);
        }

        public IPlanet FindByName(string name)
        {
            return this.planets.Find(p => p.Name == name);
        }

        public bool RemoveItem(string name)
        {
            return this.planets.Remove(this.planets.FirstOrDefault(p => p.Name == name));
        }
    }
}
