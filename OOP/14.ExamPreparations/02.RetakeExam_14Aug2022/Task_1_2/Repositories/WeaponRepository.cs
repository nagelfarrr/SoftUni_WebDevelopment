using System;
using System.Collections.Generic;
using System.Text;

namespace PlanetWars.Repositories
{
    using PlanetWars.Models.Weapons;
    using PlanetWars.Models.Weapons.Contracts;
    using PlanetWars.Repositories.Contracts;

    public class WeaponRepository : IRepository<IWeapon>
    {
        private List<IWeapon> weapons;

        public WeaponRepository()
        {
            this.weapons = new List<IWeapon>();
        }

        public IReadOnlyCollection<IWeapon> Models => this.weapons.AsReadOnly();

        public void AddItem(IWeapon model)
        {
            this.weapons.Add(model);
        }

        public IWeapon FindByName(string name)
        {
            return this.weapons.Find(w => w.GetType().Name == name);
        }

        public bool RemoveItem(string name)
        {
            return this.weapons.Remove(this.weapons.Find(w => w.GetType().Name == name));
        }
    }
}
