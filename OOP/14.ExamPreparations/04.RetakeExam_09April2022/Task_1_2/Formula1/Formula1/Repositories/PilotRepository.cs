namespace Formula1.Repositories
{
    using System.Collections.Generic;
    using Formula1.Models.Contracts;
    using Formula1.Repositories.Contracts;

    public class PilotRepository : IRepository<IPilot>
    {
        private List<IPilot> pilots;

        public PilotRepository()
        {
            pilots = new List<IPilot>();
        }

        public IReadOnlyCollection<IPilot> Models => this.pilots.AsReadOnly();
        public void Add(IPilot model)
        {
            this.pilots.Add(model);
        }

        public bool Remove(IPilot model)
        {
            return this.pilots.Remove(model);
        }

        public IPilot FindByName(string name)
        {
            return this.pilots.Find(p => p.FullName == name);
        }
    }
}
