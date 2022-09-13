using System;
using System.Collections;
using System.Collections.Generic;

namespace _06.Supermarket
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            Queue<string> customers = new Queue<string>();

            while (input != "End")
            {
                switch (input)
                {
                    case "Paid":
                        while (customers.Count > 0)
                        {
                            Console.WriteLine(customers.Dequeue());
                        }
                        break;

                    default:
                        customers.Enqueue(input);
                        break;
                }
                input = Console.ReadLine();
            }

            Console.WriteLine($"{customers.Count} people remaining.");
        }

        
    }
}
