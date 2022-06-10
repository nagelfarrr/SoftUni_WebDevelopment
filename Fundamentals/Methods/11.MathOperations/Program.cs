using System;

namespace _11.MathOperations
{
    class Program
    {
        static void Main(string[] args)
        {
            double firstNumber = double.Parse(Console.ReadLine());
            string operation = Console.ReadLine();
            double secondNumber = double.Parse(Console.ReadLine());

            
            Console.WriteLine(Calculate(firstNumber, operation, secondNumber));
        }

        static double Calculate(double firstNumber, string operation, double secondNumber)
        {
            double result = 0;
            switch (operation)
            {
                case "/":
                    result = firstNumber / secondNumber;
                    break;
                case "*":
                    result =firstNumber * secondNumber;
                    break;
                case "+":
                    result = firstNumber + secondNumber;
                    break;
                case "-":
                    result = firstNumber - secondNumber;
                    break;
            }

            return result;
        }
    }
}
