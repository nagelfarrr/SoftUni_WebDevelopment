using System;

namespace _06.StrongNumber
{
    class Program
    {
        static void Main(string[] args)
        {
            int num = int.Parse(Console.ReadLine());
            int newNum = 0;
            int numHolder = num;
            int sum = 0;

            while (numHolder > 0)
            {
                int numFactorial = 1;
                newNum = numHolder % 10;
                numHolder = numHolder / 10;

                for (int i = 1; i <= newNum; i++)
                {
                    numFactorial *= i;


                }
                sum += numFactorial;
            }

            if (sum == num) 
            {
                Console.WriteLine("yes");
            }
            else
            {
                Console.WriteLine("no");
                
            }

        }
    }
}
