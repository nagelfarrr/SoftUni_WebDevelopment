using System;

namespace _04.TextFilter
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] banList = Console.ReadLine().Split(", ");

            string text = Console.ReadLine();
            Ban(banList,text);
            Console.WriteLine(Ban(banList,text));
        }

        static string Ban(string[] banList, string text)
        {

            for (int i = 0; i < banList.Length; i++)
            {
                banList[i] += "*";
            }

            return text;
        }
    }
}
