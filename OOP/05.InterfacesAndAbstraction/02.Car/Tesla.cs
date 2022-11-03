using System;
using System.Collections.Generic;
using System.Text;

namespace Cars
{
    public class Tesla : IElectricCar
    {
        public Tesla(string model, string color, int batteries)
        {
            this.Model = model;
            this.Color = color;
            this.Battery = batteries;
        }

        public string Model { get; set; }
        public string Color { get; set; }
        public int Battery { get; set; }


        public void Start()
        {
            Console.WriteLine("Engine start");

        }

        public void Stop()
        {
            Console.WriteLine("Breaaak!");
        }


        public override string ToString()
        {
            return $"{this.Color} Tesla {this.Model} with {this.Battery} Batteries";
        }
    }
}
