using System;
using System.Collections.Generic;

namespace _03.Order
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, double> productsPrice = new Dictionary<string, double>();
            Dictionary<string, int> productsCount = new Dictionary<string, int>();

            while (true)
            {
                string input = Console.ReadLine();
                if (input == "buy") break;

                string[] commands = input.Split();
                string product = commands[0];
                double price = double.Parse(commands[1]);
                int quantity = int.Parse(commands[2]);

                if (!productsPrice.ContainsKey(product))
                {
                    productsPrice.Add(product, price*quantity);
                    productsCount.Add(product, quantity);
                }
                else
                {
                    productsPrice[product] = price;
                    productsCount[product] += quantity;
                    productsPrice[product] = price * productsCount[product];
                }
                

            }

            foreach (var product in productsPrice)
            {
                Console.WriteLine($"{product.Key} -> {product.Value:f2}");
            }

        }
    }
}
