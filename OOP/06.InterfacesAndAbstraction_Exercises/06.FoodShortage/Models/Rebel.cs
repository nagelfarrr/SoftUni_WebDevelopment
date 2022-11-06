namespace _06.FoodShortage.Models
{
    using _06.FoodShortage.Models.Contracts;

    public class Rebel : ICitizen,IBuyer
    {
        public Rebel(string name, int age, string group)
        {
            this.Name = name;
            this.Age = age;
            this.Group = group;
            this.Food = 0;
        }


        public string Name { get; }
        public int Age { get; }

        public string Group { get; set; }
        public int Food { get; set; }
        public void BuyFood()
        {
            this.Food += 5;
        }
    }
}
