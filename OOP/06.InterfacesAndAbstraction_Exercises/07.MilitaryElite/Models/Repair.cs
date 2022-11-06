namespace _07.MilitaryElite.Models
{
    using System.Text;

    public class Repair
    {
        public string PartName { get; set; }
        public int HoursWorked { get; set; }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Part Name: {this.PartName} Hours Worked: {this.HoursWorked}");

            return sb.ToString().Trim();
        }
    }
}
