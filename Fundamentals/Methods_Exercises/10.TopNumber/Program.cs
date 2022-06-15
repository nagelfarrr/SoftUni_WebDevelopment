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

            PrintTopNumber(number);
        }

        static void PrintTopNumber(int number)
        {
            for (int i = 1; i < number; i++)
            {
                GetSum(i);
            }
        }

        static void GetSum(int number)
        {
            int sum = 0;
            int printNumber = number;
            bool isNumberOdd = false;

            while (number > 0)
            {
                int tempNumber = number % 10;
                sum += tempNumber;
                if (tempNumber % 2 != 0)
                {
                    isNumberOdd = true;
                }

                number /= 10;
            }

            if (sum % 8 == 0 && isNumberOdd)
            {
                Console.WriteLine(printNumber);
            }
        }
    }
}
