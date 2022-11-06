namespace _07.MilitaryElite.Models
{
    using System.Collections.Generic;
    using System.Text;

    using Contracts;

    public class Commando : SpecialisedSoldier,ICommando
    {
        public Commando(string id, string firstName, string lastName, decimal salary, string corps, HashSet<Mission> missions) : base(id, firstName, lastName, salary, corps)
        {
            this.Missions = missions;
        }

        public HashSet<Mission> Missions { get; set; }


        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Name: {this.FirstName} {this.LastName} Id: {this.Id} Salary: {this.Salary:F2}");
            if (this.Corps != null)
            {
                sb.AppendLine($"Corps: {this.Corps}");
            }

            sb.AppendLine("Missions:");
            foreach (var mission in this.Missions)
            {
                sb.AppendLine($"{mission}");
            }

            return sb.ToString().Trim();
        }
    }
}
