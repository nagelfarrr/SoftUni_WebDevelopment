namespace Raiding.Models
{
    public abstract class BaseHero
    {
        protected BaseHero(string name)
        {
            this.Name = name;
        }
        public string Name { get; set; }
        public int Power { get; set; }


        public abstract string CastAbility();

    }
}
