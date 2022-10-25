using System;
using System.Collections.Generic;
using System.Text;

namespace RawData
{
    public class Tire
    {

        public Tire(int age, float pressure)
        {
            this.Age = age;
            this.Pressure = pressure;
        }
        public int Age { get; set; }
        public float Pressure { get; set; }
    }
}
