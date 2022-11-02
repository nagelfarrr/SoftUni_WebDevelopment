using System;

namespace _04.PizzaCalories
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            string pizzaName = Console.ReadLine().Split()[1];

            string[] doughtInput = Console.ReadLine().Split();

            string flour = doughtInput[1];
            string baking = doughtInput[2];
            double weight = double.Parse(doughtInput[3]);
            try
            {
                Dough dough = new Dough(flour, baking, weight);
                Pizza pizza = new Pizza(pizzaName, dough);


                while (true)
                {
                    string input = Console.ReadLine();
                    if (input == "END") break;

                    string toppingType = input.Split()[1];
                    double toppingWeight = double.Parse(input.Split()[2]);

                    Topping topping = new Topping(toppingType, toppingWeight);
                    pizza.AddTopping(topping);
                }

                Console.WriteLine(pizza);
            }
            catch (ArgumentException ae)
            {
                Console.WriteLine(ae.Message);
            }
        }
    }
}
