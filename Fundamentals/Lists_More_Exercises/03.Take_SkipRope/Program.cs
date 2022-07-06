using System;
using System.Diagnostics.CodeAnalysis;
using System.Linq;

namespace _03.Take_SkipRope
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string encryptedMessage = Console.ReadLine();

            List<int> digits = new List<int>();
            List<char> chars = new List<char>();

            for (int i = 0; i < encryptedMessage.Length; i++)
            {
                
                if (encryptedMessage[i] >= 48 && encryptedMessage[i] <= 57)
                {
                    int digit = int.Parse(encryptedMessage[i]);
                    digits.Add(digit);

                }
                else
                {
                    chars.Add(encryptedMessage[i]);
                }
            }

            Console.WriteLine(string.Join(" ", digits));
            Console.WriteLine(string.Join(' ', chars));
        }
    }
}