using System;
using System.Collections.Generic;
using System.Linq;

namespace _01.RandomizeWords
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string str = Console.ReadLine();

            List<string> strList = str.Split().ToList();

            Random rnd = new Random();

            for (int i = 0; i < strList.Count; i++)
            {
                int randomIndex = rnd.Next(0, strList.Count);
                string currentWord = strList[i];
                strList[i] = strList[randomIndex];
                strList[randomIndex] = currentWord;
            }

            foreach (var word in strList)
            {
                Console.WriteLine(word);
            }
        }
    }
}