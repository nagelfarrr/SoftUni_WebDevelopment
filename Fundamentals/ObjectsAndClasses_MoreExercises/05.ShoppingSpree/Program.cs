using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

namespace _05.ShoppingSpree
{
    class Program
    {
        static void Main(string[] args)
        {
            var availableProducts = new List<Product>();
            var persons = new List<Person>();
            
            var bagOfProducts = new List<Product>();

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

                var product = availableProducts.Find(p => p.Name == commands[1]);

                var person = persons.Find(p => p.Name == commands[0]);
               
                    if (person.Money >= product.Cost)
                    {
                        person.Products.Add(product);
                        person.Money = person.Money - product.Cost;
                        Console.WriteLine($"{person.Name} bought {product.Name}");
                    }
                    else
                    {
                        Console.WriteLine($"{person.Name} can't afford {product.Name}");
                    }
                

                
            }

            foreach (var person in persons)
            {
                if (person.Products.Count > 0)
                {
                    Console.WriteLine($"{person.Name} - " + string.Join(", ", person.Products));
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
        public override string ToString()
        {
            return this.Name;
        }

        public Product(string productName)
        {
            this.Name = productName;
        }

        public string Name { get; set; }
        public double Cost { get; set; }
    }
}
