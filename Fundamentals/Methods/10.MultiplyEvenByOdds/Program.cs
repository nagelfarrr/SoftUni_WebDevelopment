using System;


namespace _10.MultiplyEvenByOdds
{
    class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());
            number = Math.Abs(number);

            int evenSum = GetSumOfEvenDigits(number);
            int oddSum = GetSumOfOddDigits(number);
            int result = GetMultipleOfEvenAndOdds(evenSum, oddSum);

            Console.WriteLine(result);
        }
        static int GetMultipleOfEvenAndOdds(int evenSum, int oddSum)
        {
            return evenSum * oddSum;
        }

        static int GetSumOfEvenDigits(int number)
        {
            int evenSum = 0;
            int digits = number;

            for (int i = digits; i >= 0; i--)
            {
                int tempNum = digits % 10;
                if (tempNum % 2 == 0)
                {
                    evenSum += tempNum;
                }

                digits /= 10;
            }

            return evenSum;
        }
        static int GetSumOfOddDigits(int number)
        {
            
            int oddSum = 0;
            int digits = number;
            for (int i = number; i >= 0; i--)
            {
                int tempNum = number % 10;
                if (tempNum % 2 != 0)
                {
                    oddSum += tempNum;
                }

                number /= 10;
            }

            return oddSum;
        }

    }
}
