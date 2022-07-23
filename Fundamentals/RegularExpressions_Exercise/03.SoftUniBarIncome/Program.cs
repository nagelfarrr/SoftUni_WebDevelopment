using System;
using System.Text.RegularExpressions;

namespace _03.SoftUniBarIncome
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string pattern = @"^%(?<customer>[A-Z][a-z]+)%[^|$%.]*<(?<product>\w+)>[^|$%.]*\|(?<quantity>[0-9]{1,})\|[^|$%.]*?(?<price>[0-9]+(\.[0-9]+)?)\$";

            Regex regex = new Regex(pattern);
            double totalIncome = 0.0;
            while (true)
            {
                string input = Console.ReadLine();
                if (input == "end of shift") break;
                Match match = regex.Match(input);
                if (match.Success)
                {
                    string customer = match.Groups["customer"].Value;
                    string product = match.Groups["product"].Value;
                    int quantity = int.Parse(match.Groups["quantity"].Value);
                    double price = double.Parse(match.Groups["price"].Value);

                    totalIncome += quantity * price;
                    Console.WriteLine($"{customer}: {product} - {(quantity * price):f2}");
                }
            }

            Console.WriteLine($"Total income: {totalIncome:f2}");
        }
    }
}
