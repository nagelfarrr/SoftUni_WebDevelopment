namespace Easter.Repositories
{
    using System.Collections.Generic;
    using System.Linq;
    using Easter.Models.Bunnies.Contracts;
    using Easter.Repositories.Contracts;

    public class BunnyRepository : IRepository<IBunny>
    {
        private List<IBunny> models;

        public BunnyRepository()
        {
            this.models = new List<IBunny>();
        }

        public IReadOnlyCollection<IBunny> Models => this.models.AsReadOnly();
        public void Add(IBunny model)
        {
            this.models.Add(model);
        }

        public bool Remove(IBunny model)
        {
            return this.models.Remove(model);
        }

        public IBunny FindByName(string name)
        {
            return this.models.FirstOrDefault(m => m.Name == name);
        }
    }
}
