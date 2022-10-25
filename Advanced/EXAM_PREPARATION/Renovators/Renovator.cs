using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Renovators
{
    public class Renovator
    {
		private string name;
        private string type;
        private double rate;
        private int days;
        private bool hired = false;

        public Renovator(string name, string type, double rate, int days)
        {
            this.Name = name;
            this.Type = type;
            this.Rate = rate;
            this.Days = days;
        }

		public string Name
		{
			get { return this.name; }
			set { this.name = value; }
		}

        public string Type
        {
            get { return this.type;}
            set { this.type = value; }
        }

        public double Rate
        {
            get { return this.rate;}
            set { this.rate = value; }
        }

        public int Days
        {
            get { return this.days;}
            set { this.days = value; }
        }

        public bool Hired
        {
            get { return this.hired;}
            set { this.hired = value; }
        }


        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"-Renovator: {this.Name}");
            sb.AppendLine($"--Specialty: {this.Type}");
            sb.AppendLine($"--Rate per day: {this.Rate} BGN");

            return sb.ToString().Trim();
        }
    }
}
