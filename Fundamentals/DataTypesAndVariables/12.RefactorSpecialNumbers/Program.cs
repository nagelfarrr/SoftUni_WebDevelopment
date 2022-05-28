using System;

namespace _12.RefactorSpecialNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int input = int.Parse(Console.ReadLine());
                        
            for (int i = 1; i <= input; i++)

            {
                int sum = 0;
                int digits = i;

                while (digits > 0)

                {

                    sum += digits % 10;

                    digits = digits / 10;

                }

                bool isSpecialNumber = (sum == 5) || (sum == 7) || (sum == 11);

                Console.WriteLine("{0} -> {1}", i, isSpecialNumber);





            }
        }
    }
}
