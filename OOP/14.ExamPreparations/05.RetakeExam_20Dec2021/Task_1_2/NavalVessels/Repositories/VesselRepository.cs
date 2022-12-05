namespace NavalVessels.Repositories
{
    using System.Collections.Generic;
    using NavalVessels.Models.Contracts;
    using NavalVessels.Repositories.Contracts;

    public class VesselRepository : IRepository<IVessel>
    {
        private readonly List<IVessel> vessels;

        public VesselRepository()
        {
            this.vessels = new List<IVessel>();
        }

        public IReadOnlyCollection<IVessel> Models
        {
            get => this.vessels.AsReadOnly();
        }
        public void Add(IVessel model)
        {
            this.vessels.Add(model);
        }

        public bool Remove(IVessel model)
        {
            return this.vessels.Remove(model);
        }

        public IVessel FindByName(string name)
        {
            return this.vessels.Find(v => v.Name == name);
        }
    }
}
