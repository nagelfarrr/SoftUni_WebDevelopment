using System;

namespace _05.Orders
{
    class Program
    {
        static void Main(string[] args)
        {
            string product = Console.ReadLine();
            int productQuantity = int.Parse(Console.ReadLine());

            PrintPrice(product,productQuantity);

        }
        static void PrintPrice(string product, int productQuantity)
        {
            double productPrice = 0;
            switch (product)
            {
                case "coffee":
                    productPrice = 1.50;
                    break;
                case "water":
                    productPrice = 1.00;
                    break;
                case "coke":
                    productPrice = 1.40;
                    break;
                case"snacks":
                    productPrice = 2.00;
                    break;
            }

            double result = productQuantity * productPrice;

            Console.WriteLine($"{result:f2}");
        }
    }
}
