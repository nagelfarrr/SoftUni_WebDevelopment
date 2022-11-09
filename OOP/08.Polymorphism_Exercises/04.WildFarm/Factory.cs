
namespace WildFarm
{
    using WildFarm.Models;

    public class Factory
    {
        public static Animal GetAnimal(string input)
        {
            string[] animalInfo = input.Split();
            string animalType = animalInfo[0];
            string name = animalInfo[1];
            double weight = double.Parse(animalInfo[2]);

            switch (animalType)
            {
                case "Hen": return new Hen(name, weight, double.Parse(animalInfo[3]));
                case "Owl": return new Owl(name, weight, double.Parse(animalInfo[3]));
                case "Cat": return new Cat(name, weight, animalInfo[3], animalInfo[4]);
                case "Tiger": return new Tiger(name, weight, animalInfo[3], animalInfo[4]);
                case "Dog": return new Dog(name, weight, animalInfo[3]);
                case "Mouse": return new Mouse(name, weight, animalInfo[3]);
                default: return null;
            }
        }

        public static Food GetFood(string input)
        {
            string[] foodInfo = input.Split();
            string foodType = foodInfo[0];
            int quantity = int.Parse(foodInfo[1]);

            switch (foodType)
            {
                case "Fruit": return new Fruit(quantity);
                case "Meat": return new Meat(quantity);
                case "Seeds": return new Seeds(quantity);
                case "Vegetable": return new Vegetable(quantity);
                default: return null;
            }
        }

    }
}
