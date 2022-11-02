using System;
using System.Collections.Generic;
using System.Reflection.Metadata;
using System.Text;

namespace _03.ShoppingSpree
{
    public class Person
    {
        private List<Product> bagOfProducts;
        private string name;
        private decimal money;
        private Person()
        {
            this.bagOfProducts = new List<Product>();

        }

        public Person(string name, decimal money) : this()
        {
            this.Name = name;
            this.Money = money;
        }

        public IReadOnlyCollection<Product>  BagOfProducts => this.bagOfProducts.AsReadOnly();

        public string Name
        {
            get => this.name;
            set
            {
                if (string.IsNullOrEmpty(value) || string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("Name cannot be empty");
                this.name = value;
            }
        }

        public decimal Money
        {
            get => this.money;
            set
            {
                if (value < 0)
                    throw new ArgumentException("Money cannot be negative");
                this.money = value;
            }
        }


        public void BuyProduct(Product product)
        {
            if (this.Money >= product.Cost)
            {
                Console.WriteLine($"{this.Name} bought {product}");
                this.Money -= product.Cost;
                this.bagOfProducts.Add(product);
            }
            else
            {
                Console.WriteLine($"{this.Name} can't afford {product}");
            }
        }

     
    }
}
