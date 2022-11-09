using System;

namespace WildFarm.Models
{
    public class Cat : Feline
    {
        private const double WeightGain = 0.30;

        public Cat(string name, double weight, string livingRegion, string breed) : base(name, weight, livingRegion, breed)
        {
        }

        public override string ProduceSound()
        {
            return "Meow";
        }

        public override void Eat(Food food)
        {
            if (food.GetType().Name == "Meat" || food.GetType().Name == "Vegetable")
            {
                this.Weight += WeightGain * food.Quantity;
                this.FoodEaten += food.Quantity;
            }
            else
            {
                Console.WriteLine($"{this.GetType().Name} does not eat {food.GetType().Name}!");
            }
        }
    }
}
