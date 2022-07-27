using System;
using System.Linq;

namespace WorldTour
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            while (true)
            {
                string command = Console.ReadLine();
                if (command == "Travel")
                {
                    Console.WriteLine($"Ready for world tour! Planned stops: " + input);
                    break;
                }

                string[] tokens = command.Split(':');
                string cmd = tokens[0];

                switch (cmd)
                {
                    case "Add Stop": //Insert the given string at that index only if the index is valid
                        int index = int.Parse(tokens[1]);
                        string stringToAdd = tokens[2];
                        if (index < input.Length && index >= 0)
                        {
                            input = input.Insert(index, stringToAdd);
                        }

                        Console.WriteLine(input);
                        break;

                    case "Remove Stop": //Remove the elements of the string from the starting index to the end index (inclusive) if both indices are valid
                        int startIndex = int.Parse(tokens[1]);
                        int endIndex = int.Parse(tokens[2]);
                        if ((startIndex >= 0 && startIndex < input.Length) && (endIndex >= 0 && endIndex < input.Length) &&((endIndex - startIndex+1) >=0) && (endIndex-startIndex +1) < input.Length)
                        {
                            input = input.Remove(startIndex, endIndex - startIndex + 1);
                        }

                        Console.WriteLine(input);
                        break;

                    case "Switch": //If the old string is in the initial string, replace it with the new one (all occurrences)
                        string oldString = tokens[1];
                        string newString = tokens[2];
                        if (input.Contains(oldString))
                        {
                            input = input.Replace(oldString, newString);
                        }

                        Console.WriteLine(input);
                        break;
                }
            }

            //Console.WriteLine($"Ready for world tour! Planned stops: " + input);
        }
    }
}
