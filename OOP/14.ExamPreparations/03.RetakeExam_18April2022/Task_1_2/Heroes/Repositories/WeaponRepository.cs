namespace Heroes.Repositories
{
    using System.Collections.Generic;
    using System.Linq;
    using Heroes.Models.Contracts;
    using Heroes.Repositories.Contracts;

    public class WeaponRepository : IRepository<IWeapon>
    {
        private List<IWeapon> weapons;

        public WeaponRepository()
        {
            this.weapons = new List<IWeapon>();
        }
        public IReadOnlyCollection<IWeapon> Models
        {
            get => this.weapons.AsReadOnly();
        }
        public void Add(IWeapon model)
        {
            this.weapons.Add(model);
        }

        public bool Remove(IWeapon model)
        {
            return this.weapons.Remove(model);
        }

        public IWeapon FindByName(string name)
        {
            return this.weapons.Find(w => w.Name == name);
        }
    }
}
