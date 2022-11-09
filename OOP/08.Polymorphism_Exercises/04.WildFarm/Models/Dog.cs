using System;

namespace WildFarm.Models
{
    public class Dog : Mammal
    {
        private const double WeightGain = 0.40;

        public Dog(string name, double weight, string livingRegion) : base(name, weight, livingRegion)
        {
        }

        public override string ToString()
        {
            return $"{this.GetType().Name} [{this.Name}, {this.Weight}, {this.LivingRegion}, {this.FoodEaten}]";
        }

        public override string ProduceSound()
        {
            return "Woof!";
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
