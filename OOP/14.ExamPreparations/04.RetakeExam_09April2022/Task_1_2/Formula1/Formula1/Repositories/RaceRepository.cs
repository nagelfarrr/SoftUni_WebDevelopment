namespace Formula1.Repositories
{
    using System.Collections.Generic;
    using Formula1.Models.Contracts;
    using Formula1.Repositories.Contracts;

    public class RaceRepository :IRepository<IRace>
    {
        private List<IRace> races;

        public RaceRepository()
        {
            races = new List<IRace>();
        }

        public IReadOnlyCollection<IRace> Models => this.races.AsReadOnly();
        public void Add(IRace model)
        {
            this.races.Add(model);
        }

        public bool Remove(IRace model)
        {
            return this.races.Remove(model);
        }

        public IRace FindByName(string name)
        {
            return this.races.Find(r => r.RaceName == name);
        }
    }
}
