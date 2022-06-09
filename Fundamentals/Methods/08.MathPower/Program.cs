using System;

namespace _08.MathPower
{
    class Program
    {
        static void Main(string[] args)
        {
            double baseNumber = double.Parse(Console.ReadLine());
            double powerNumber = double.Parse(Console.ReadLine());

            Console.WriteLine(RaiseToPower(baseNumber,powerNumber));
        }

        static double RaiseToPower(double baseNumber, double powerNumber)
        {
            double result = Math.Pow(baseNumber, powerNumber);

            return result;
        }
    }
}
