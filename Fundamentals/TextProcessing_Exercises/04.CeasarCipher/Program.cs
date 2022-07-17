using System;

namespace _04.CeasarCipher
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            string result = string.Empty;

            for (int i = 0; i < input.Length; i++)
            {
                result += (char)(input[i]+3);
            }

            Console.WriteLine(result);
        }
    }
}
