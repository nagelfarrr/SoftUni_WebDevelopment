using System;
using System.Collections.Generic;
using System.Linq;

namespace FoodFinder
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Queue<char> vowels = new Queue<char>(Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(c => char.Parse(c)));

            Stack<char> consonants = new Stack<char>(Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(c => char.Parse(c)));

            List<string> foods = new List<string>() { "pear", "flour", "pork", "olive" };

            HashSet<char> usedLetters = new HashSet<char>();


            while (consonants.Any())
            {
                char currentVowel = vowels.Dequeue();
                vowels.Enqueue(currentVowel);
                char currentConsonant = consonants.Pop();

                usedLetters.Add(currentConsonant);
                usedLetters.Add(currentVowel);

            }

            List<string> result = new List<string>();
            foreach (var food in foods)
            {
                if (string.Join("", food.Intersect(usedLetters)) == food)
                {
                    result.Add(food);
                }
            }

            Console.WriteLine($"Words found: {result.Count}");
            foreach (var word in result)
            {

                Console.WriteLine(word);
            }
        }
    }
}
