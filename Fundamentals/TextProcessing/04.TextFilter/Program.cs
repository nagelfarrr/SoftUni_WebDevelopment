using System;

namespace _04.TextFilter
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] banList = Console.ReadLine().Split(", ");

            string text = Console.ReadLine();

            foreach (var word in banList)
            {
                string asterisks = new string('*', word.Length);

                text = text.Replace(word, asterisks);
            }

            Console.WriteLine(text);


        }
    }
}
