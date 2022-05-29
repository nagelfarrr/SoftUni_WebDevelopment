using System;

namespace _05.PrintPartOfTheASCIITable
{
    class Program
    {
        static void Main(string[] args)
        {
            int start = int.Parse(Console.ReadLine());
            int end = int.Parse(Console.ReadLine());

            for (int i = start; i <= end; i++)
            {
                char chr = (char)i;
                Console.Write($"{chr} ");
            }
        }
    }
}
