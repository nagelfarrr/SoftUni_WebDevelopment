using System.Text;

namespace Drones
{
    public class Drone
    {
        private string name;
        private string brand;
        private int range;
        private bool available;


        public Drone(string name, string brand, int range)
        {
            this.Name = name;
            this.Brand = brand;
            this.Range = range;
            this.Available = true;
        }

        public string Name
        {
            get { return this.name; }
            set { this.name = value; }
        }

        public string Brand
        {
            get { return this.brand; }
            set { this.brand = value; }
        }

        public int Range
        {
            get { return this.range; }
            set { this.range = value; }
        }

        public bool Available
        {
            get { return this.available; }
            set { this.available = value; }
        }


        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Drone: {this.Name}");
            sb.AppendLine($"Manufactured by: {this.Brand}");
            sb.AppendLine($"Range: {this.Range} kilometers");

            return sb.ToString().Trim();
        }
    }
}
