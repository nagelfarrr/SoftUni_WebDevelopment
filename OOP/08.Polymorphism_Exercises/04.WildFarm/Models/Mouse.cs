using System;

namespace WildFarm.Models
{
    public class Mouse : Mammal
    {
        private const double WeightGain = 0.10;

        public Mouse(string name, double weight, string livingRegion) : base(name, weight, livingRegion)
        {
        }

        public override string ToString()
        {
            return $"{this.GetType().Name} [{this.Name}, {this.Weight}, {this.LivingRegion}, {this.FoodEaten}]";
        }

        public override string ProduceSound()
        {
            return "Squeak";
        }

        public override void Eat(Food food)
        {
            if (food.GetType().Name == "Vegetable" || food.GetType().Name == "Fruit")
            {
                this.Weight += WeightGain * food.Quantity;
                this.FoodEaten += food.Quantity;
            }
            else
                Console.WriteLine($"{this.GetType().Name} does not eat {food.GetType().Name}!");
        }
    }
}
