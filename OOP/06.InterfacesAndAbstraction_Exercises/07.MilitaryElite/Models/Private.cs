namespace _07.MilitaryElite.Models
{
    using System.Text;

    using Contracts;

    public class Private : Soldier, IPrivate
    {
        public Private(string id, string firstName, string lastName,decimal salary) : base(id, firstName, lastName)
        {
            this.Salary = salary;
        }

        public decimal Salary { get; set; }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Name: {this.FirstName} {this.LastName} Id: {this.Id} Salary: {this.Salary:F2}");

            return sb.ToString().TrimEnd();
        }
    }
}
