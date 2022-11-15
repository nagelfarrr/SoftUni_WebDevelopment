using System;

namespace _05.PlayCatch
{
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Linq;

    public class Program
    {
        static void Main(string[] args)
        {
            int[] integers = Console.ReadLine().Split(" ").Select(n => int.Parse(n)).ToArray();

            int exceptionCounter = 0;

            while (exceptionCounter != 3)
            {
                string[] commands = Console.ReadLine().Split(" ");
                string cmd = commands[0];

                try
                {
                    switch (cmd)
                    {

                        case "Replace":
                            int index = int.Parse(commands[1]);
                            int element = int.Parse(commands[2]);
                            integers[index] = element;
                            break;

                        case "Print":
                            int startIndex = int.Parse(commands[1]);
                            int endIndex = int.Parse(commands[2]);

                            List<int> newElements = new List<int>();
                            for (int i = startIndex; i <= endIndex; i++)
                            {
                                newElements.Add(integers[i]);
                            }

                            Console.WriteLine(string.Join(", ", newElements));
                            break;

                        case "Show":
                            int indexToShow = int.Parse(commands[1]);

                            Console.WriteLine($"{integers[indexToShow]}");
                            break;
                    }
                }
                catch (IndexOutOfRangeException)
                {
                    exceptionCounter++;
                    Console.WriteLine("The index does not exist!");
                }
                catch (FormatException)
                {
                    exceptionCounter++;
                    Console.WriteLine("The variable is not in the correct format!");
                }


            }
            
            Console.WriteLine(string.Join(", ", integers));
        }
    }
}
