using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace TilesMaster
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] whiteTiles = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(n => int.Parse(n)).ToArray();

            int[] greyTiles = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(n => int.Parse(n)).ToArray();

            Stack<int> whites = new Stack<int>(whiteTiles);
            Queue<int> greys = new Queue<int>(greyTiles);

            Dictionary<string, int> kitchenRequirements = new Dictionary<string, int>()
            {
                { "Sink", 40 },
                { "Oven", 50 },
                { "Countertop", 60 },
                { "Wall", 70 },
            };

            Dictionary<string, int> finalizedKitchen = new Dictionary<string, int>();


            int sumTile = 0;
            bool isTileFloor = false;
            while (true)
            {

                if (whites.Count == 0 || greys.Count ==0)
                    break;

                if (whites.Peek() == greys.Peek())
                {
                    sumTile = whites.Pop() + greys.Dequeue();

                    foreach (var req in kitchenRequirements)
                    {
                        isTileFloor = false;
                        if (req.Value == sumTile)
                        {
                            if (!finalizedKitchen.ContainsKey(req.Key))
                            {
                                finalizedKitchen.Add(req.Key, 1);
                            }
                            else
                            {
                                finalizedKitchen[req.Key]++;
                            }

                            break;
                        }
                        else
                        {
                            

                            isTileFloor = true;
                        }
                    }

                    if (isTileFloor)
                    {
                        if (!finalizedKitchen.ContainsKey("Floor"))
                        {
                            finalizedKitchen.Add("Floor", 1);
                        }
                        else
                        {
                            finalizedKitchen["Floor"]++;
                        }
                    }
                }

                else
                {
                    whites.Push(whites.Pop()/2);
                    greys.Enqueue(greys.Dequeue());
                }
            }

            

            if (whites.Count == 0)
            {
                Console.WriteLine($"White tiles left: none");
            }
            else
            {
                Console.WriteLine($"White tiles left: {string.Join(", ",whites)}");
            }

            if (greys.Count == 0)
            {
                Console.WriteLine($"Grey tiles left: none");
            }
            else
            {
                Console.WriteLine($"Grey tiles left: {string.Join(", ", greys)}");
            }

            foreach (var kitch in finalizedKitchen.OrderByDescending(x=>x.Value).ThenBy(x=>x.Key))
            {
                Console.WriteLine($"{kitch.Key}: {kitch.Value}");
            }

        }
    }
}
