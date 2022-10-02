using System;
using System.Collections.Generic;
using System.Linq;

namespace _04.ProductShop
{
    internal class Program
    {
        static void Main(string[] args)
        {
            SortedDictionary<string, Dictionary<string, double>> shops = new SortedDictionary<string, Dictionary<string, double>>();

            string input = Console.ReadLine();

            while (input!= "Revision")
            {
                string[] tokens = input.Split(", ", StringSplitOptions.RemoveEmptyEntries);
                string shopName = tokens[0];
                string product = tokens[1];
                double productPrice = double.Parse(tokens[2]);

                if (!shops.ContainsKey(shopName))
                    shops.Add(shopName, new Dictionary<string, double>());

                shops[shopName].Add(product,productPrice);

                input = Console.ReadLine();
            }

            
            foreach (var shop in shops)
            {
                Console.WriteLine($"{shop.Key}->");
                foreach (var product in shop.Value)
                {
                    Console.WriteLine($"Product: {product.Key}, Price: {product.Value}");
                }
            }
        }
    }
}
