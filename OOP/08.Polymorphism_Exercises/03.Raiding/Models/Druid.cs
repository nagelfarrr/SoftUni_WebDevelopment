namespace Raiding.Models
{
    internal class Druid :BaseHero
    {
        public Druid(string name) : base(name)
        {
            this.Power = 80;
        }

        public override string CastAbility()
        {
            return $"{this.GetType().Name} - {this.Name} healed for {this.Power}";
        }
    }
}
