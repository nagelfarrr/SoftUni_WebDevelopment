using System;

namespace WildFarm.Models
{
    public class Owl : Bird
    {
        private const double WeightGain = 0.25;
        public Owl(string name, double weight, double wingSize) : base(name, weight, wingSize)
        {
        }

        public override string ProduceSound()
        {
            return "Hoot Hoot";
        }

        public override void Eat(Food food)
        {
            if (food.GetType().Name == "Meat")
            {
                this.Weight += WeightGain * food.Quantity;
                this.FoodEaten += food.Quantity;
            }
            else
                Console.WriteLine($"{this.GetType().Name} does not eat {food.GetType().Name}!");
        }
    }
}
