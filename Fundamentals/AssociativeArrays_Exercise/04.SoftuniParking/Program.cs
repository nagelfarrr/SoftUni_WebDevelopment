using System;
using System.Collections.Generic;

namespace _04.SoftuniParking
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, string> registeredUsers = new Dictionary<string, string>();

            int numberOfCommands = int.Parse(Console.ReadLine());

            for (int i = 0; i < numberOfCommands; i++)
            {
                string[] commands = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
                
                switch (commands[0])
                {
                    case "register":
                        if (!registeredUsers.ContainsKey(commands[1]))
                        {
                            registeredUsers[commands[1]] = commands[2];
                            Console.WriteLine($"{commands[1]} registered {commands[2]} successfully");
                        }
                        else
                        {
                            Console.WriteLine($"ERROR: already registered with plate number {commands[2]}");
                        }
                        break;
                    case "unregister":
                        if (!registeredUsers.ContainsKey(commands[1]))
                        {
                            Console.WriteLine($"ERROR: user {commands[1]} not found");

                        }
                        else
                        {
                            registeredUsers.Remove(commands[1]);
                            Console.WriteLine($"{commands[1]} unregistered successfully");
                        }
                        break;
                }


            }
            foreach (var user in registeredUsers)
            {
                Console.WriteLine($"{user.Key} => {user.Value}");
            }
        }
    }
}
