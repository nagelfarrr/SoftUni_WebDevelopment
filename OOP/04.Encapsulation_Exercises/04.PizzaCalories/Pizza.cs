using System;
using System.Collections.Generic;

namespace _04.PizzaCalories
{
    public class Pizza
    {
        private string name;
        private List<Topping> toppings;
        private Dough dough;

        public Pizza(string name, Dough dough)
        {
            this.toppings = new List<Topping>();
            this.Name = name;
            this.Dough = dough;
        }



        public string Name
        {
            get => this.name;
            set
            {
                if (string.IsNullOrEmpty(value) || string.IsNullOrWhiteSpace(value) || value.Length > 15)
                    throw new ArgumentException("Pizza name should be between 1 and 15 symbols.");
                this.name = value;
            }
        }

        public Dough Dough
        {
            get => this.dough;
            set => this.dough = value;
        }

        public int ToppingsCount
        {
            get => this.toppings.Count;
        }

        public double TotalCalories
        {
            get
            {
                double totalCalories = this.dough.GetCalories();
                foreach (var topping in this.toppings)
                {
                    totalCalories += topping.GetCalories();
                }

                return totalCalories;
            }
        }


        public void AddTopping(Topping topping)
        {
            if (this.ToppingsCount == 10)
                throw new ArgumentException("Number of toppings should be in range [0..10].");

            toppings.Add(topping);
        }

        public override string ToString()
        {
            return $"{this.Name} - {this.TotalCalories:f2} Calories.";
        }
    }
}
