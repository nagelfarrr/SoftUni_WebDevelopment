using System;

namespace CarRacing.Models.Cars
{
    public class TunedCar : Car
    {
        public TunedCar(string make, string model, string vin, int horsePower) 
            : base(make, model, vin, horsePower, 65, 7.5)
        { }

        public override void Drive()
        {
            base.Drive();
            this.HorsePower -= (int)Math.Round(this.HorsePower * 0.03);
            
        }
    }
}
