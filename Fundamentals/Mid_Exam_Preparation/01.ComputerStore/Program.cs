using System;

namespace _01.ComputerStore
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = string.Empty;

            double totalPrice = 0;
            while (true)
            {
                input = Console.ReadLine();
                if (input == "special" || input == "regular")
                {
                    break;
                }
                double price = double.Parse(input);

                if (price < 0)
                {
                    Console.WriteLine("Invalid price!");
                    continue;
                }
                else
                {
                    totalPrice += price;
                }
                
            }

            double taxes = totalPrice * 0.2;
            double finalPrice = totalPrice + taxes;
            if (finalPrice <= 0)
            {
                Console.WriteLine("Invalid order!"); 
                return;
            }
            if (input == "special")
            {
                finalPrice *= 0.9;
            }

            Console.WriteLine($"Congratulations you've just bought a new computer!\n" +
                              $"Price without taxes: {totalPrice:f2}$\n" +
                              $"Taxes: {taxes:f2}$\n" +
                              $"-----------\n" +
                              $"Total price: {finalPrice:f2}$");


        }
    }
}
