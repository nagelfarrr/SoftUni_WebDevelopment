namespace _04.BorderControl.Models.Contracts
{
    public interface ICitizen : IPopulation
    {
        public string Name { get; }
        public int Age { get; }
    
    }
}
