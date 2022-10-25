using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ComputerArchitecture
{
    public class Computer
    {

        public Computer(string model, int capacity)
        {
            this.Model = model;
            this.Capacity = capacity;
            this.Multiprocessor = new List<CPU>();
        }

        public string Model { get; set; }
        public int Capacity { get; set; }
        public List<CPU> Multiprocessor { get; set; }

        public int Count
        {
            get { return this.Multiprocessor.Count; }
        }

        public void Add(CPU cpu)
        {
            if (this.Count < this.Capacity)
            {
                this.Multiprocessor.Add(cpu);
            }
        }

        public bool Remove(string brand)
        {
            return this.Multiprocessor.Remove(this.Multiprocessor.Find(c => c.Brand == brand));
        }

        public CPU MostPowerful()
        {
            var mostPowerful = this.Multiprocessor.OrderByDescending(c => c.Frequency).First();
            return mostPowerful;
        }

        public CPU GetCPU(string brand)
        {
            return this.Multiprocessor.Find(c => c.Brand == brand);
        }

        public string Report()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"CPUs in the Computer {this.Model}:");
            foreach (var cpu in Multiprocessor)
            {
                sb.AppendLine(cpu.ToString());
            }

            return sb.ToString().Trim();
        }
    }
}
