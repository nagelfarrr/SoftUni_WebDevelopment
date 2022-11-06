namespace _07.MilitaryElite.Models.Contracts
{
    using System.Collections.Generic;

    public interface ICommando
    {
        HashSet<Mission> Missions { get; set; }
    }
}
