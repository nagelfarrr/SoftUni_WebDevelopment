using System;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using System.Linq;

namespace _03.MemoryGame
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> elements = Console.ReadLine()
                .Split()
                .ToList();

            string[] input = Console.ReadLine().Split();

            int movesCount = 0;

            while (input[0] != "end")
            {
                string firstIndex = input[0];
                string secondIndex = input[1];


                for (int i = 0; i < 1; i++)
                {
                    movesCount++;
                    if (firstIndex == secondIndex ||
                        int.Parse(firstIndex) < 0 ||
                        int.Parse(secondIndex) < 0 ||
                        int.Parse(firstIndex) > elements.Count-1 ||
                        int.Parse(secondIndex) > elements.Count-1)
                    {
                        elements.Insert(elements.Count / 2, "-"+movesCount + "a");
                        elements.Insert(elements.Count / 2, "-"+movesCount + "a");
                        Console.WriteLine("Invalid input! Adding additional elements to the board");
                    }

                    else if (elements[int.Parse(firstIndex)] == elements[int.Parse(secondIndex)])
                    {
                        Console.WriteLine($"Congrats! You have found matching elements - {elements[int.Parse(firstIndex)]}!");
                        if (int.Parse(secondIndex) > int.Parse(firstIndex))
                        {
                            elements.RemoveAt(int.Parse(secondIndex));
                            elements.RemoveAt(int.Parse(firstIndex));
                        }
                        else
                        {
                            elements.RemoveAt(int.Parse(firstIndex));
                            elements.RemoveAt(int.Parse(secondIndex));
                        }
                    }
                    else
                    {
                        Console.WriteLine("Try again!");
                    }

                    if (elements.Count == 0)
                    {
                        Console.WriteLine($"You have won in {movesCount} turns!");
                        return;
                    }
                }

                input = Console.ReadLine().Split();
            }

            if (elements.Count > 0)
            {
                Console.WriteLine("Sorry you lose :(");
                Console.WriteLine(string.Join(" ", elements));
            }

        }
    }
}
