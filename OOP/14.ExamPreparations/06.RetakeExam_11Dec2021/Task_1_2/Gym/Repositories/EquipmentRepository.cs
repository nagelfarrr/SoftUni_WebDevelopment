namespace Gym.Repositories
{
    using System.Collections.Generic;
    using System.Linq;
    using Gym.Models.Equipment.Contracts;
    using Gym.Repositories.Contracts;

    public class EquipmentRepository : IRepository<IEquipment>
    {
        private List<IEquipment> models;

        public EquipmentRepository()
        {
            this.models = new List<IEquipment>();
        }

        public IReadOnlyCollection<IEquipment> Models
        {
            get => this.models.AsReadOnly();
        }
        public void Add(IEquipment model)
        {
            this.models.Add(model);
        }

        public bool Remove(IEquipment model)
        {
            return this.models.Remove(model);
        }

        public IEquipment FindByType(string type)
        {
            return this.models.FirstOrDefault(e => e.GetType().Name == type);
        }
    }
}
