using System;

namespace _11.Orders
{
    class Program
    {
        static void Main(string[] args)
        {
            int countOfOrders = int.Parse(Console.ReadLine());

            double pricePerDay = 0;
            double coffeePrice = 0;
            double totalprice = 0;

            for (int i = 1; i <= countOfOrders; i++)
            {
                double capsulePrice = double.Parse(Console.ReadLine());
                int days = int.Parse(Console.ReadLine());
                int capsuleQty = int.Parse(Console.ReadLine());
                pricePerDay = days * capsuleQty * capsulePrice;
                coffeePrice += pricePerDay;
                Console.WriteLine($"The price for the coffee is: ${pricePerDay:f2}");
            }
            Console.WriteLine($"Total: ${coffeePrice:f2}");
        }
    }
}
