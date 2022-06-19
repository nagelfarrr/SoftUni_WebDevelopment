using System;
using System.Collections.Generic;
using System.Threading.Channels;

namespace _04.ListOfProducts
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberOfProducts = int.Parse(Console.ReadLine());
            List<string> productList = new List<string>();
            for (int i = 0; i < numberOfProducts; i++)
            {
                string product = Console.ReadLine();
                productList.Add(product);
                
            }

            productList.Sort();
            for (int i = 0; i < productList.Count; i++)
            {
                Console.WriteLine($"{i+1}.{productList[i]}");
            }
        }
    }
}
