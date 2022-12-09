namespace CarRacing.Models.Cars
{
    public class SuperCar : Car
    {
        public SuperCar(string make, string model, string vin, int horsePower) 
            : base(make, model, vin, horsePower, 80, 10)
        {
        }
    }
}
