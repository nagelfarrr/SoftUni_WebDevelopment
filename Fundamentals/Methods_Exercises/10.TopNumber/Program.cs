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
            bool isThereOddDigit = IsThereOddDigit(number);
            bool isSumOfDigitsDivisble = IsSumOfDigitsDivisble(number);

            for (int i = 1; i <= number; i++)
            {
                if (isThereOddDigit && isSumOfDigitsDivisble)
                {
                    Console.Write(i);
                }
            }
        }
        static bool IsThereOddDigit(int number)
        {
            bool isThereOddDigit = false;
            while (number > 0)
            {
                int currentDigit = number % 10;
                if (currentDigit % 2 != 0)
                {
                    isThereOddDigit = true;
                    break;

                }
                else
                {
                    isThereOddDigit = false;
                }

                number = number / 10;
            }


            //for (int i = 0; i < endValue.Length; i++)
            //{
            //    int currentDigit = endValue[i];
            //
            //    
            //}

            if (isThereOddDigit) return true;
            else return false;
        }

        static bool IsSumOfDigitsDivisble(int number)
        {
            int sumOfDigits = 0;

            for (int i = 1; i <= number; i++)
            {
                int tempNumber = i;
                sumOfDigits = 0;
                while (tempNumber > 0)
                {
                    int currentNumber =tempNumber % 10;
                    sumOfDigits += currentNumber;
                    tempNumber /= 10;
                }
            }
            
            if (sumOfDigits % 8 == 0) return true;
            else return false;
        }
    }
}
