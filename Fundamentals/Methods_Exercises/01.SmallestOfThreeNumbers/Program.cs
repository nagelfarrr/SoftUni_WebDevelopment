using System;

namespace _01.SmallestOfThreeNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int num1 = int.Parse(Console.ReadLine());
            int num2 = int.Parse(Console.ReadLine());
            int num3 = int.Parse(Console.ReadLine());
            PrintSmallestNumber(num1,num2,num3);
        }

        static void PrintSmallestNumber(int num1, int num2, int num3)
        {
            int[] arr = { num1, num2, num3 };
            Array.Sort(arr);
            Console.WriteLine(arr[0]);
        }
    }
}
