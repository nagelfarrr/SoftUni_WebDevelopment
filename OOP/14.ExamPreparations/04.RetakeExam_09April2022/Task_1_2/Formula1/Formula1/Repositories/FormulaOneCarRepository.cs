namespace Formula1.Repositories
{
    using System.Collections.Generic;
    using Formula1.Models.Contracts;
    using Formula1.Repositories.Contracts;

    public class FormulaOneCarRepository : IRepository<IFormulaOneCar>
    {
        private List<IFormulaOneCar> f1Cars;

        public FormulaOneCarRepository()
        {
            f1Cars = new List<IFormulaOneCar>();
        }

        public IReadOnlyCollection<IFormulaOneCar> Models => this.f1Cars.AsReadOnly();
        public void Add(IFormulaOneCar model)
        {
            f1Cars.Add(model);
        }

        public bool Remove(IFormulaOneCar model)
        {
            return f1Cars.Remove(model);
        }

        public IFormulaOneCar FindByName(string name)
        {
            return f1Cars.Find(f => f.Model == name);
        }
    }
}
