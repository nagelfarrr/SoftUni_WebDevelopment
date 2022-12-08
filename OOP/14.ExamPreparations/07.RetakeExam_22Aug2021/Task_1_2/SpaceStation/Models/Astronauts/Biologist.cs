namespace SpaceStation.Models.Astronauts
{
    public class Biologist : Astronaut
    {
        public Biologist(string name) : 
            base(name, 70)
        { }

        public override void Breath()
        {

            if (this.Oxygen - 5 < 0)
            {
                this.Oxygen = 0;
            }
            else
            {
                this.Oxygen -= 5;
            }
            
        }
    }
}
