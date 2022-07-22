using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace _01.Furniture
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string pattern = @">>(?<product>[A-Za-z\s]+)<<(?<price>\d+(.\d+)?)!(?<quantity>\d+)";

            Regex regex = new Regex(pattern);

            List<string> items = new List<string>();
            double totalPrice = 0.0;
            while (true)
            {
                string input = Console.ReadLine();
                if (input == "Purchase") break;

                Match match = regex.Match(input);
                if (match.Success)
                {
                    string productName = match.Groups["product"].Value;
                    double price = double.Parse(match.Groups["price"].Value);
                    int quantity = int.Parse(match.Groups["quantity"].Value);
                    totalPrice += price * quantity;
                    items.Add(productName);
                    
                }
            }

            Console.WriteLine("Bought furniture:");
            if (items.Count > 0)
            {
                foreach (var item in items)
                {

                    Console.WriteLine($"{item}");
                }

            }
            Console.WriteLine($"Total money spend: {totalPrice:f2}");
        }
    }
}
