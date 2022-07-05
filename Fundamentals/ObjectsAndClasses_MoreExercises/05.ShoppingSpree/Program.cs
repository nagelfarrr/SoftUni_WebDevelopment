using System;
using System.Collections.Generic;
using System.Linq;

namespace _05.ShoppingSpree
{
    class Program
    {
        static void Main(string[] args)
        {
            var availableProducts = new List<Product>();
            var persons = new List<Person>();
            var finalListOfPeople = new List<Person>();

            string[] people = Console.ReadLine().Split(';');
            for (int i = 0; i < people.Length; i++)
            {
                string[] personTokens = people[i].Split('=');
                var person = new Person(personTokens[0], double.Parse(personTokens[1]));
                persons.Add(person);
            }
            string[] numberOfProducts = Console.ReadLine().Split(';');
            for (int i = 0; i < numberOfProducts.Length; i++)
            {
                string[] productsTokens = numberOfProducts[i].Split('=');
                var product = new Product(productsTokens[0]){Cost = double.Parse(productsTokens[1])};
                availableProducts.Add(product);
            }

            while (true)
            {
                string input = Console.ReadLine();
                if (input == "END") break;
                string[] commands = input.Split();
                var productToBuy = availableProducts.Find(p=> p.Name == commands[1]);

                var personOrder = persons.Find(p => p.Name == commands[0]);

                if (persons.First(p=> p.Name == commands[0]))
                {
                    Console.WriteLine($"{personOrder.Name} bought {productToBuy.Name}");
                    personOrder.Money -= productToBuy.Cost;
                    personOrder.Products.Add(productToBuy);
                    
                }
                else
                {
                    Console.WriteLine($"{personOrder.Name} can't afford {productToBuy.Name}");
                }
            }

            foreach (var person in finalListOfPeople)
            {
                if (person.Products.Count > 0)
                {
                    Console.WriteLine($"{person.Name} - {string.Join(", ", person.Products)}");
                }
                else
                {
                    Console.WriteLine($"{person.Name} - Nothing bought");
                }
            }


        }
    }


    public class Person
    {
        public Person(string name, double money)
        {
            this.Name = name;
            this.Money = money;
            this.Products = new List<Product>();
        }

        public string Name { get; set; }
        public double Money { get; set; }
        public List<Product> Products { get; set; }
    }

    public class Product
    {
        public Product(string productName)
        {
            this.Name = productName;
        }

        public string Name { get; set; }
        public double Cost { get; set; }
    }
}
