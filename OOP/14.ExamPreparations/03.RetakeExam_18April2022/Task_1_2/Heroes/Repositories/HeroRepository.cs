namespace Heroes.Repositories
{
    using System.Collections.Generic;
    using System.Linq;
    using Heroes.Models.Contracts;
    using Heroes.Repositories.Contracts;

    public class HeroRepository : IRepository<IHero>
    {
        private List<IHero> heroes;

        public HeroRepository()
        {
            this.heroes = new List<IHero>();
        }

        public IReadOnlyCollection<IHero> Models
        {
            get => this.heroes.AsReadOnly();
        }
        public void Add(IHero model)
        {
            this.heroes.Add(model);
        }

        public bool Remove(IHero model)
        {
            return this.heroes.Remove(model);
        }

        public IHero FindByName(string name)
        {
            return this.heroes.Find(h => h.Name == name);
        }
    }
}
