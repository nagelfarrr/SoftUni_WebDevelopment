using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Transactions;

namespace BakeryShop
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, double> productsWaterPercentage = new Dictionary<string, double>()
            {
                { "Croissant", 50 },
                { "Muffin", 40 },
                { "Baguette", 30 },
                { "Bagel", 20 },
            };

            Queue<double> water = new Queue<double>(Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(n => double.Parse(n)));
            Stack<double> flour = new Stack<double>(Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(n => double.Parse(n)));

            Dictionary<string, int> result = new Dictionary<string, int>();

            while (true)
            {
                if (water.Count == 0) break;
                if (flour.Count == 0) break;

                double currWater = water.Dequeue();
                double currFlour = flour.Pop();
                double sum = currWater + currFlour;
                double waterPercents = currWater * 100 / sum;

                bool isProductBaked = true;
                foreach (var product in productsWaterPercentage)
                {
                    if (product.Value == waterPercents)
                    {
                        
                        if(!result.ContainsKey(product.Key))
                            result.Add(product.Key,0);

                        result[product.Key]++;
                        isProductBaked = true;
                        break;
                    }
                    else
                    {
                        isProductBaked = false;
                    }
                }

                if (!isProductBaked)
                {
                    double tempFlour = currFlour;
                    currFlour = currWater;
                    tempFlour -= currFlour;
                    flour.Push(tempFlour);

                    if (!result.ContainsKey("Croissant"))
                    {
                        result.Add("Croissant", 0);
                    }

                    result["Croissant"]++;
                }
            }

            foreach (var product in result.OrderByDescending(p=>p.Value).ThenBy(p=>p.Key))
            {
                Console.WriteLine($"{product.Key}: {product.Value}");
            }

            if (water.Count > 0)
            {
                Console.WriteLine($"Water left: {string.Join(", ",water)}");
            }
            else
            {
                Console.WriteLine("Water left: None");
            }

            if (flour.Count > 0)
            {
                Console.WriteLine($"Flour left: {string.Join(", ",flour)}");
            }
            else
            {
                Console.WriteLine("Flour left: None");
            }
        }
    }
}
