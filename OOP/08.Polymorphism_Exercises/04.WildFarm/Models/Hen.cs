namespace WildFarm.Models
{
    public class Hen : Bird
    {
        private const double WeightGain = 0.35;

        public Hen(string name, double weight, double wingSize) : base(name, weight, wingSize)
        {
        }

        public override string ProduceSound()
        {
            return "Cluck";
        }

        public override void Eat(Food food)
        {
            this.Weight += WeightGain * food.Quantity;
            this.FoodEaten += food.Quantity;
        }
    }
}
