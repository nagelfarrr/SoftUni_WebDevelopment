using System;
using System.Collections.Generic;

namespace _06.Wardrobe
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, Dictionary<string, int>> wardrobeDictionary = new Dictionary<string, Dictionary<string, int>>();

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine().Split(" -> ", StringSplitOptions.RemoveEmptyEntries);
                string color = input[0];
                string[] clothes = input[1].Split(",");

                if(!wardrobeDictionary.ContainsKey(color))
                    wardrobeDictionary.Add(color,new Dictionary<string, int>());

                for (int j = 0; j < clothes.Length; j++)
                {
                    string currentCloth = clothes[j];

                    if (!wardrobeDictionary[color].ContainsKey(currentCloth))
                        wardrobeDictionary[color].Add(currentCloth,0);

                    wardrobeDictionary[color][currentCloth]++;
                }

            }

            string[] findClothes = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

            foreach (var wardrobe in wardrobeDictionary)
            {
                Console.WriteLine($"{wardrobe.Key} clothes:");
                foreach (var cloth in wardrobe.Value)
                {
                    string clothes = $"* {cloth.Key} - {cloth.Value}";
                    if (wardrobe.Key == findClothes[0] && cloth.Key == findClothes[1])
                        clothes += " (found!)";

                    Console.WriteLine(clothes);
                }
            }
        }
    }
}
