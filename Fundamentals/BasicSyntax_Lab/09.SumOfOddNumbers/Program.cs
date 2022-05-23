using System;

namespace _09.SumOfOddNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());
            var sum = 0;
            var counter = 0;
            for (int i = 1; i <= 100; i += 2)
            {


                Console.WriteLine(i);
                sum += i;
                counter++;
                if (counter == n)
                {
                    Console.WriteLine($"Sum: {sum}");
                    break;
                }
            }

        }
    }
}
