namespace BirthdayCelebrations.Models.Contracts
{
    public interface ICitizen : IPopulation,IBirthable
    {
        public string Name { get; }
        public int Age { get; }
        

    }
}
