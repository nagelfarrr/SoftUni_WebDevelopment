using System;
using System.Linq;
using System.Net;

namespace _10.TopNumber
{
    class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());

            bool isDigitOdd = false;
            bool isSumDivisible = false;


            int sum = 0;
            for (int i = 15; i <= number; i++)
            {
                int tempNumber = i;
                tempNumber = tempNumber % 10;

                if (tempNumber % 2 != 0)
                {
                    isDigitOdd = true;
                    sum += tempNumber;
                    if (sum % 8 == 0)
                    {
                        isSumDivisible = true;
                        Console.WriteLine(i);
                    }
                }

                tempNumber = i;
                tempNumber /= 10;
               // sum = 0;
            }
        }







    }
}
