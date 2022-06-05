using System;

namespace _09.SpiceMustFlow
{
    class Program
    {
        static void Main(string[] args)
        {
            int startingYield = int.Parse(Console.ReadLine());

            
            int dayCount = 0;
            int totalAmount = 0;
            if (startingYield < 100)
            {
                Console.WriteLine(dayCount);
                Console.WriteLine(totalAmount);
            }
            else
            {

                while (startingYield >= 100)
                {

                    dayCount++;
                    totalAmount += startingYield - 26;
                    startingYield -= 10;
                }

                totalAmount -= 26;
                Console.WriteLine(dayCount);
                Console.WriteLine(totalAmount);
            }
        }
    }
}
