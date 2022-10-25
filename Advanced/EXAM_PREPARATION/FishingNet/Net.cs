using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FishingNet
{
    public class Net
    {
        private List<Fish> fish;

        public Net(string material, int capacity)
        {
            this.fish = new List<Fish>();
            this.Material = material;
            this.Capacity = capacity;
        }

        public List<Fish> Fish
        {
            get { return this.fish; }
        }
        public string Material { get; set; }
        public int Capacity { get; set; }
        public int Count
        {
            get { return this.fish.Count; }
        }

        public string AddFish(Fish fish)
        {

            if (string.IsNullOrEmpty(fish.FishType) || fish.Weight <= 0 || fish.Length <= 0)
            {
                return "Invalid fish.";
            }
            if (this.Count == this.Capacity)
                return "Fishing net is full.";

            this.fish.Add(fish);
            return $"Successfully added {fish.FishType} to the fishing net.";


        }

        public bool ReleaseFish(double weight)
        {
            return this.Fish.Remove(fish.Find(f => f.Weight == weight));

        }

        public Fish GetFish(string fishType)
        {
            return this.Fish.Find(f => f.FishType == fishType);
        }

        public Fish GetBiggestFish()
        {
            return this.Fish.OrderByDescending(f => f.Length).First();
        }

        public string Report()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"Into the {this.Material}:");

            foreach (var fish in this.fish.OrderByDescending(f => f.Length))
            {
                sb.AppendLine(fish.ToString());
            }

            return sb.ToString().Trim();
        }
    }
}
