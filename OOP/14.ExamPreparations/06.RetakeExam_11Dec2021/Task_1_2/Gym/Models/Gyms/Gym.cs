namespace Gym.Models.Gyms
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using global::Gym.Models.Athletes.Contracts;
    using global::Gym.Models.Equipment.Contracts;
    using global::Gym.Models.Gyms.Contracts;
    using global::Gym.Utilities.Messages;

    public abstract class Gym : IGym
    {
        private string name;
        private List<IEquipment> equipment;
        private List<IAthlete> athletes;

        public Gym(string name, int capacity)
        {
            this.equipment = new List<IEquipment>();
            this.athletes = new List<IAthlete>();

            this.Name = name;
            this.Capacity = capacity;
        }

        public string Name
        {
            get => this.name;
            private set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException(ExceptionMessages.InvalidGymName);
                }
                this.name = value;
            }
        }
        public int Capacity { get; private set; }
        public ICollection<IEquipment> Equipment
        {
            get => this.equipment;
        }

        public ICollection<IAthlete> Athletes
        {
            get => this.athletes;
        }

        public double EquipmentWeight
        {
            get
            {
                return this.Equipment.Sum(e => e.Weight);
            }
        }

        public void AddAthlete(IAthlete athlete)
        {
            if (this.Athletes.Count == this.Capacity)
            {
                throw new InvalidOperationException(ExceptionMessages.NotEnoughSize);
            }
            this.Athletes.Add(athlete);
        }

        public bool RemoveAthlete(IAthlete athlete)
        {
            return this.Athletes.Remove(athlete);
        }

        public void AddEquipment(IEquipment equipment)
        {
            this.Equipment.Add(equipment);
        }

        public void Exercise() // might not work !!! 
        {
            foreach (var athlete in this.Athletes)
            {
                athlete.Exercise();
            }
        }

        public string GymInfo()
        {
            StringBuilder sb = new StringBuilder();

            string athletesStr = this.Athletes.Any() ? string.Join(", ", this.Athletes.Select(a=>a.FullName)) : "No athletes";

            sb.AppendLine($"{this.Name} is a {this.GetType().Name}:");
            sb.AppendLine($"Athletes: {athletesStr}");
            sb.AppendLine($"Equipment total count: {this.Equipment.Count}");
            sb.AppendLine($"Equipment total weight: {this.EquipmentWeight:F2} grams");

            return sb.ToString().TrimEnd();
        }
    }
}
