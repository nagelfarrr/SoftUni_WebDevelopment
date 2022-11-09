namespace WildFarm.Models
{

    public abstract class Animal
    {
       protected  Animal(string name, double weight)
       {
           this.Name = name;
           this.Weight = weight;
           this.FoodEaten = 0;
       }

        public string Name { get; set; }
        public double Weight { get; set; }
        public int FoodEaten { get; set; }


        public virtual string ProduceSound()
        {
            return "";
        }

        public abstract void Eat(Food food);
    }
}
