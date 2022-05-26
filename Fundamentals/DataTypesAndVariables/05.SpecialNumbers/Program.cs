using System;

namespace _05.SpecialNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            //A number is special when its sum of digits is 5, 7 or 11.
            //Range is between 1 and numberRange
            int numberRange = int.Parse(Console.ReadLine());
            bool isSpecial = false; ;

            for (int i = 1; i <= numberRange; i++)
            {
                int sum = 0;
                int currentNum = i;

                while (currentNum!=0)
                {
                    sum += currentNum % 10;
                    currentNum /= 10;
                }

                if (sum == 5 || sum == 7 || sum == 11)
                {
                    isSpecial = true;
                    Console.WriteLine($"{i} -> {isSpecial}");
                }
                else
                {
                    isSpecial = false;
                    Console.WriteLine($"{i} -> {isSpecial}");
                }
            }

            
        }
    }
}
