
namespace Heroes.Models.Weapons
{
    public class Mace : Weapon
    {
        public Mace(string name, int durability) : base(name, durability)
        {
        }

        public override int DoDamage()
        {
            
                this.Durability--;
            
            if (this.Durability <= 0)
            {
                return 0;
            }
            return 25;
        }
    }
}
