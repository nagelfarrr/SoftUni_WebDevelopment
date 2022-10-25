using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Drones
{
    public class Airfield
    {
        private List<Drone> drones;
        private string name;
        private int capacity;
        private double landingStrip;

        public Airfield(string name, int capacity, double landingStrip)
        {
            this.Name = name;
            this.Capacity = capacity;
            this.LandingStrip = landingStrip;
            this.Drones = new List<Drone>();
        }


        public List<Drone> Drones { get; set; }
        public string Name { get; set; }
        public int Capacity { get; set; }
        public double LandingStrip { get; set; }
        public int Count
        {
            get { return this.Drones.Count; }
        }

        public string AddDrone(Drone drone)
        {
            if (string.IsNullOrEmpty(drone.Name) || string.IsNullOrEmpty(drone.Brand) ||
                drone.Range < 5 || drone.Range > 15)
            {
                return "Invalid drone.";
            }
            else if (this.Capacity == this.Drones.Count)
            {
                return "Airfield is full.";
            }

            this.Drones.Add(drone);
            return $"Successfully added {drone.Name} to the airfield.";
        }

        public bool RemoveDrone(string name)
        {
            var droneToRemove = this.Drones.Find(d => d.Name == name);
            return this.Drones.Remove(droneToRemove);
        }

        public int RemoveDroneByBrand(string brand)
        {
            return this.Drones.RemoveAll(d => d.Brand == brand);
        }

        public Drone FlyDrone(string name)
        {
            var droneToFly = this.Drones.Find(d => d.Name == name);
            if (droneToFly != null)
            {
                droneToFly.Available = false;
                
            }

            return droneToFly;
        }

        public List<Drone> FlyDronesByRange(int range)
        {
            var dronesToFly = this.Drones.Where(d => d.Range >= range).ToList();

            foreach (var drone in dronesToFly)
            {
                this.FlyDrone(drone.Name);
            }

            return dronesToFly;
        }

        public string Report()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Drones available at {this.Name}:");
            foreach (var drone in this.Drones.Where(d => d.Available).ToList())
            {
                sb.AppendLine(drone.ToString());
            }

            return sb.ToString().Trim();
        }
    }
}
