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
            List<char> characters = new List<char>();

            foreach (var chr in encryptedMessage)
            {
                if (chr > 0 && chr < 9)
                {
                    digits.Add(chr);
                }
                else characters.Add(chr);
            }
            List<int> takeList = new List<int>();
            List<int> skipList = new List<int>();
            for (int i = 0; i < digits.Count; i++)
            {
                if(i%2 == 0) takeList.Add(digits[i]);
                else skipList.Add(digits[i]);
            }

            var result = string.Empty;
            for (int i = 0; i < skipList.Count; i++)
            {
                int skipCount = skipList[i];
                result += characters.Skip(skipCount).ToString();
                for (int j = 0; j < takeList.Count; j++)
                {
                    int takeCount = takeList[j];
                    result += characters.AddRange(takeCount);
                }

            }
        }
    }
}