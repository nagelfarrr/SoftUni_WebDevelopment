namespace Easter.Repositories
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Runtime.CompilerServices;
    using Easter.Models.Eggs.Contracts;
    using Easter.Repositories.Contracts;

    public class EggRepository :IRepository<IEgg>
    {
        private List<IEgg> models;

        public EggRepository()
        {
            this.models = new List<IEgg>();
        }

        public IReadOnlyCollection<IEgg> Models => this.models.AsReadOnly();
        public void Add(IEgg model)
        {
            this.models.Add(model);
        }

        public bool Remove(IEgg model)
        {
            return this.models.Remove(model);
        }

        public IEgg FindByName(string name)
        {
            return this.models.FirstOrDefault(m => m.Name == name);
        }
    }
}
