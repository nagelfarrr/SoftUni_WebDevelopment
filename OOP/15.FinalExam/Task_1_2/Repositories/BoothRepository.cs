namespace ChristmasPastryShop.Repositories
{
    using System.Collections.Generic;
    using System.Drawing;
    using ChristmasPastryShop.Models.Booths.Contracts;
    using ChristmasPastryShop.Repositories.Contracts;

    public class BoothRepository : IRepository<IBooth>
    {
        private List<IBooth> models;

        public BoothRepository()
        {
            this.models = new List<IBooth>();
        }

        public IReadOnlyCollection<IBooth> Models => this.models.AsReadOnly();
        public void AddModel(IBooth model)
        {
            this.models.Add(model);
        }
    }
}
