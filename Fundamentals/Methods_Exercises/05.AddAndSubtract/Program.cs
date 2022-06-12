using System;

namespace _05.AddAndSubtract
{
    class Program
    {
        static void Main(string[] args)
        {
            int num1 = int.Parse(Console.ReadLine());
            int num2 = int.Parse(Console.ReadLine());
            int num3 = int.Parse(Console.ReadLine());

            //sum = num3-(num1+num2)
            Console.WriteLine(SubtractNumbers(num1, num2, num3));
                
        }

        static int AddNumbers(int num1, int num2)
        {
            return num1 + num2;
        }

        static int SubtractNumbers(int num1, int num2, int num3)
        {
            return AddNumbers(num1, num2) - num3;
        }
    }
}
