using System;

namespace _02.VowelsCount
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            Console.WriteLine(VowelCounts(input));
        }

        static int VowelCounts(string str)
        {
            int count = 0;
            string vowels = "aoeiu";

            foreach (char ch in str.ToLower())
            {
                if (vowels.Contains(ch))
                {
                    count++;
                }
            }
            return count;
        }
    }
}
