namespace _07.MilitaryElite.Models.Contracts
{
    using System.Collections.Generic;

    public interface ILieutenantGeneral
    {
        HashSet<Private> Privates { get; set; }
    }
}
