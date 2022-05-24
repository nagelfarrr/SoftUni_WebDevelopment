using System;

namespace _04.ReverseString
{
    class Program
    {
        static void Main(string[] args)
        {
            string str = Console.ReadLine();
            char[] charArray = str.ToCharArray();
            string reverse = string.Empty;

            for (int i = charArray.Length -1 ; i >= 0; i--)
            {
                reverse += charArray[i];
            }
            Console.WriteLine(reverse);
        }
    }
}
