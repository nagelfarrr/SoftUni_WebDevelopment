using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Blacksmith
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, int> swords = new Dictionary<string, int>()
            {
                {"Gladius", 70},
                {"Shamshir", 80},
                {"Katana", 90},
                {"Sabre", 110},
                {"Broadsword", 150},
            };

            Queue<int> steel = new Queue<int>(Console.ReadLine().Split(" ",StringSplitOptions.RemoveEmptyEntries).Select(n=>int.Parse(n)));
            Stack<int> carbon = new Stack<int>(Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(n => int.Parse(n)));

            Dictionary<string, int> forgedSwords = new Dictionary<string, int>();

            while (true)
            {
                if (steel.Count == 0) break;
                if(carbon.Count == 0) break;

                bool isForged = false;
                int sum = steel.Peek() + carbon.Peek();

                foreach (var sword in swords)
                {
                    if (sword.Value == sum)
                    {
                        isForged = true;
                        if (!forgedSwords.ContainsKey(sword.Key))
                        {
                            forgedSwords.Add(sword.Key, 0);
                        }
                        forgedSwords[sword.Key]++;
                        break;
                    }
                    else
                    {
                        isForged = false;
                    }
                }

                if (isForged)
                {
                    steel.Dequeue();
                    carbon.Pop();
                }
                else
                {
                    steel.Dequeue();
                    carbon.Push(carbon.Pop()+5);
                }
            }

            if (forgedSwords.Any())
            {
                int forgedSwordsCount = forgedSwords.Values.Sum();
                Console.WriteLine($"You have forged {forgedSwordsCount} swords.");
            }
            else
            {
                Console.WriteLine("You did not have enough resources to forge a sword.");
            }

            if (steel.Any())
            {
                Console.WriteLine($"Steel left: {string.Join(", ",steel)}");
            }
            else
            {
                Console.WriteLine("Steel left: none");
            }

            if (carbon.Any())
            {
                Console.WriteLine($"Carbon left: {string.Join(", ",carbon)}");
            }
            else
            {
                Console.WriteLine("Carbon left: none");
            }

            foreach (var sword in forgedSwords.OrderBy(s=>s.Key))
            {
                Console.WriteLine($"{sword.Key}: {sword.Value}");
            }
        }
    }
}
