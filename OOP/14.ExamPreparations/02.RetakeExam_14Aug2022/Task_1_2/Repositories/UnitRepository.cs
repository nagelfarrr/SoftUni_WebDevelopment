using System;
using System.Collections.Generic;
using System.Text;

namespace PlanetWars.Repositories
{
    using PlanetWars.Models.MilitaryUnits.Contracts;
    using PlanetWars.Repositories.Contracts;

    public class UnitRepository : IRepository<IMilitaryUnit>
    {
        private  List<IMilitaryUnit> militaryUnits;

        public UnitRepository()
        {
            this.militaryUnits = new List<IMilitaryUnit>();
        }

        public IReadOnlyCollection<IMilitaryUnit> Models => this.militaryUnits.AsReadOnly();
        public void AddItem(IMilitaryUnit model)
        {
            this.militaryUnits.Add(model);
        }

        public IMilitaryUnit FindByName(string name)
        {
            return this.militaryUnits.Find(m => m.GetType().Name == name);
        }

        public bool RemoveItem(string name)
        {
            return this.militaryUnits.Remove(this.militaryUnits.Find(m => m.GetType().Name == name));
        }
    }
}
