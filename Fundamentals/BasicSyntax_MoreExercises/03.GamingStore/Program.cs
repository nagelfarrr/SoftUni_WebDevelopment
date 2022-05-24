using System;

namespace _03.GamingStore
{
    class Program
    {
        static void Main(string[] args)
        {
            double money = double.Parse(Console.ReadLine());
            string input = Console.ReadLine();

            double price = 0;
            double spentmoney = 0;

            while (input != "Game Time")
            {
                

                switch (input)
                {
                    case "OutFall 4":
                        price = 39.99;
                        if (money >= price)
                        {
                            Console.WriteLine($"Bought {input}");
                            money -= price;
                            spentmoney += price;
                        }
                        else
                        {
                            Console.WriteLine("Too Expensive");
                        }
                        break;
                    case "CS: OG":
                        price = 15.99;
                        if (money >= price)
                        {
                            Console.WriteLine($"Bought {input}");
                            money -= price;
                            spentmoney += price;
                        }
                        else
                        {
                            Console.WriteLine("Too Expensive");
                        }
                        break;
                    case "Zplinter Zell":
                        price = 19.99;
                        if (money >= price)
                        {
                            Console.WriteLine($"Bought {input}");
                            money -= price;
                            spentmoney += price;
                        }
                        else
                        {
                            Console.WriteLine("Too Expensive");
                        }
                        break;
                    case "Honored 2":
                        price = 59.99;
                        if (money >= price)
                        {
                            Console.WriteLine($"Bought {input}");
                            money -= price;
                            spentmoney += price;
                        }
                        else
                        {
                            Console.WriteLine("Too Expensive");
                        }
                        break;
                    case "RoverWatch":
                        price = 29.99;
                        if (money >= price)
                        {
                            Console.WriteLine($"Bought {input}");
                            money -= price;
                            spentmoney += price;
                        }
                        else
                        {
                            Console.WriteLine("Too Expensive");
                        }
                        break;
                    case "RoverWatch Origins Edition":
                        price = 39.99;
                        if (money >= price)
                        {
                            Console.WriteLine($"Bought {input}");
                            money -= price;
                            spentmoney += price;
                        }
                        else
                        {
                            Console.WriteLine("Too Expensive");
                        }
                        break;
                    default:
                        Console.WriteLine("Not Found");
                        break;
                        
                }
                if(money <= 0)
                {
                    Console.WriteLine("Out of money!");
                    return;
                }
                input = Console.ReadLine();
            }

            Console.WriteLine($"Total spent: ${spentmoney:f2}. Remaining: ${money:f2}");
        }
    }
}
