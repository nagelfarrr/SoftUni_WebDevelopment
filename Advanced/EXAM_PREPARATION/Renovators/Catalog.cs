using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Renovators
{
    public class Catalog
    {
        private List<Renovator> renovators;

        public Catalog(string name, int neededRenovators, string project)
        {
            this.renovators = new List<Renovator>();
            this.Name = name;
            this.NeededRenovators = neededRenovators;
            this.Project = project;
        }

        public string Name { get; set; }
        public int NeededRenovators { get; set; }
        public string Project { get; set; }
        public int Count
        {
            get { return this.renovators.Count; }
        }

        public string AddRenovator(Renovator renovator)
        {
            if (this.NeededRenovators > this.renovators.Count)
            {
                if (string.IsNullOrEmpty(renovator.Name) || string.IsNullOrEmpty(renovator.Type))
                {
                    return "Invalid renovator's information.";
                }

                else if (renovator.Rate > 350)
                {
                    return "Invalid renovator's rate.";
                }
                else
                {
                    this.renovators.Add(renovator);
                    return $"Successfully added {renovator.Name} to the catalog.";
                }
            }
            else
            {
                return "Renovators are no more needed.";
            }
        }

        public bool RemoveRenovator(string name)
        {
            if (this.renovators.Exists(r => r.Name == name))
            {
                var renovator = renovators.Find(r => r.Name == name);
                this.renovators.Remove(renovator);
                return true;
            }

            return false;
        }

        public int RemoveRenovatorBySpecialty(string type)
        {
            int removedRenovatorsCount = 0;

            var removedRenovators = this.renovators.Where(r => r.Type == type).ToList();
            removedRenovatorsCount = removedRenovators.Count;

            this.renovators.RemoveAll(r => r.Type == type);

            return removedRenovatorsCount;
        }

        public Renovator HireRenovator(string name)
        {
            if (this.renovators.Exists(r => r.Name == name))
            {
                var renovator = this.renovators.Find(r => r.Name == name);
                renovator.Hired = true;
                return renovator;
            }

            return null;
        }

        public List<Renovator> PayRenovators(int days)
        {
            var payedRenovators = this.renovators.Where(r => r.Days >= days).ToList();
            return payedRenovators;
        }

        public string Report()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Renovators available for Project {this.Project}:");
           // var notHiredRenovators = renovators.FindAll(r => r.Hired ==false);
            foreach (var renovator in this.renovators.Where(r=>r.Hired == false))
            {
                sb.AppendLine(renovator.ToString());
            }

            return sb.ToString().Trim();
        }
    }
}
