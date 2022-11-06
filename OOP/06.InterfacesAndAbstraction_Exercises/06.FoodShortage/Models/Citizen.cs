namespace _06.FoodShortage.Models
{
    using _06.FoodShortage.Models.Contracts;
    using System;

    public class Citizen : ICitizen, IBirthable,IBuyer
    {
        private string name;
        private int age;
        private string id;
        private string birthdate;

        public Citizen(string name, int age, string id, string birthdate)
        {
            this.Name = name;
            this.Age = age;
            this.Id = id;
            this.Birthdate = birthdate;
            this.Food = 0;
        }

        public string Name
        {
            get => this.name;

            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Invalid name!");
                }

                this.name = value;
            }
        }

        public int Age
        {
            get => this.age;

            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Invalid age!");
                }

                this.age = value;
            }
        }

        public string Id
        {
            get => this.id;

            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Invalid ID");
                }

                this.id = value;
            }
        }

        public string Birthdate
        {
            get => this.birthdate;

            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    Console.WriteLine("Invalid birth date!");
                }

                this.birthdate = value;
            }
        }

        public int Food { get; set; }
        public void BuyFood()
        {
            this.Food += 10;
        }
    }
}
