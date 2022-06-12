using System;

namespace _08.FactorialDivision
{
    class Program
    {
        static void Main(string[] args)
        {
            int num1 = int.Parse(Console.ReadLine());
            int num2 = int.Parse(Console.ReadLine());

            CalculatingFactorials(num1, num2);
        }

        static void CalculatingFactorials(int num1, int num2)
        {
            double firstFactorial = 1;

            for (int i = num1; i > 0; i--)
            {
                firstFactorial *= i;
            }

            double secondFactorial = 1;

            for (int i = num2; i > 0; i--)
            {
                secondFactorial *= i;
            }

            double result = (firstFactorial / secondFactorial);
            Console.WriteLine($"{result:f2}");

        }
    }
}
