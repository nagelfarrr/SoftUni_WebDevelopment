namespace CarRacing.Models.Racers
{
    using CarRacing.Models.Cars.Contracts;

    public class ProfessionalRacer : Racer
    {
        public ProfessionalRacer(string username, ICar car)
            : base(username, "strict", 30, car)
        { }

        public override void Race()
        {
            base.Race();
            this.DrivingExperience += 10;
        }
    }
}
