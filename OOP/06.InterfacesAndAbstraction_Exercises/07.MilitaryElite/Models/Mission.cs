namespace _07.MilitaryElite.Models
{
    using System.Text;
    public class Mission
    {
        private string state;

        public string CodeName { get; set; }

        public string State
        {
            get => this.state; 
            set
            {
                if (value == "inProgress" || value == "Finished")
                {
                    this.state = value;
                }
            }
        }


        private void CompleteMission()
        {
            this.State = "Finished";
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Code Name: {this.CodeName} State: {this.State}");

            return sb.ToString().TrimEnd();
        }
    }
}
