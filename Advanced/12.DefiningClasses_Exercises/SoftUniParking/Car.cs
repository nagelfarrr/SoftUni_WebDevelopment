using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Schema;

namespace SoftUniParking
{
    public class Car
    {
        public Car(string make, string model, int horsePower, string registrationNumber)
        {
            this.Make = make;
            this.Model = model;
            this.HorsePower = horsePower;
            this.RegistrationNumber = registrationNumber;
        }

        public string Make { get; set; }
        public string Model { get; set; }
        public int HorsePower { get; set; }
        public string RegistrationNumber { get; set; }


        public override string ToString()
        {
            string print =
                $"Make: {this.Make}{Environment.NewLine}" +
                $"Model: {this.Model}{Environment.NewLine}" +
                $"HorsePower: {this.HorsePower}{Environment.NewLine}" +
                $"RegistrationNumber: {this.RegistrationNumber}";

            return print;
        }
    }
}
