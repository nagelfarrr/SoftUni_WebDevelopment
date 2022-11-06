namespace _07.MilitaryElite.Models.Contracts
{
    using System.Collections.Generic;

    public interface IEngineer
    {
        HashSet<Repair> Repairs { get; set; }
    }
}
