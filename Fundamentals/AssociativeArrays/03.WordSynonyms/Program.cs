using System;
using System.Collections.Generic;

namespace _03.WordSynonyms
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int numberOfWords = int.Parse(Console.ReadLine());
            Dictionary<string, List<string>> synonymDictionary = new Dictionary<string, List<string>>();

            for (int i = 0; i < numberOfWords; i++)
            {
                string word = Console.ReadLine();
                string synonym = Console.ReadLine();
                var synonyms = new List<string>();
                if (!synonymDictionary.ContainsKey(word)) synonymDictionary.Add(word, synonyms);
                synonymDictionary[word].Add(synonym);
            }

            foreach (var word in synonymDictionary)
            {
                Console.WriteLine($"{word.Key} - {string.Join(", ", word.Value)}");
            }

            
        }
    }
}
