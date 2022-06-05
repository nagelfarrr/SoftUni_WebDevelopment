using System;

namespace _04.ReverseArrayOfStrings
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] str = Console.ReadLine().Split();

            Array.Reverse(str);

            for (int i = 0; i < str.Length; i++)
            {
                Console.Write($"{str[i]} ");
            }
        }
    }
}
