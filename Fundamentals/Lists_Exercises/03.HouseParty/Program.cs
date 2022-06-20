using System;
using System.Collections.Generic;
using System.Security.Principal;

namespace _03.HouseParty
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberOfCommands = int.Parse(Console.ReadLine());
            List<string> attendees = new List<string>();
            CreatingList(attendees, numberOfCommands);
            PrintingList(attendees);
        }

        static void CreatingList(List<string> attendees, int numberOfCommands)
        {
            for (int i = 0; i < numberOfCommands; i++)
            {
                string[] commands = Console.ReadLine().Split();

                if (commands.Length == 4)
                {
                    if (attendees.Contains(commands[0]))
                    {
                        attendees.Remove(commands[0]);
                    }
                    else
                    {
                        Console.WriteLine($"{commands[0]} is not in the list!");
                    }
                }
                else
                {
                    if (attendees.Contains(commands[0]))
                    {
                        Console.WriteLine($"{commands[0]} is already in the list!");
                    }
                    else
                    {
                        attendees.Add(commands[0]);
                    }
                }
            }
        }

        static void PrintingList(List<string> attendees)
        {
            foreach (var name in attendees)
            {
                Console.WriteLine(name);
            }
        }
    }
}
