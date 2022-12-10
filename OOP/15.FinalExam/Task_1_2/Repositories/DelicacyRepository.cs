namespace ChristmasPastryShop.Repositories
{
    using System.Collections.Generic;
    using ChristmasPastryShop.Models.Delicacies.Contracts;
    using ChristmasPastryShop.Repositories.Contracts;

    public class DelicacyRepository : IRepository<IDelicacy>
    {
        private List<IDelicacy> models;

        public DelicacyRepository()
        {
            this.models = new List<IDelicacy>();
        }

        public IReadOnlyCollection<IDelicacy> Models => this.models.AsReadOnly();
        public void AddModel(IDelicacy model)
        {
            this.models.Add(model);
        }
    }
}
