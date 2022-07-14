using System;
using System.Collections.Generic;
using System.Linq;

namespace _03.Third_Task
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> commands = Console.ReadLine()
                .Split()
                .ToList();
            List<string> result = new List<string>();
            while (true)
            {
                if (commands[0] == "end") break;

                switch (commands[0])
                {
                    case "Chat":
                        result.Add(commands[1]);
                        break;
                    case "Delete":
                        if (result.Contains(commands[1])) result.Remove(commands[1]);
                        break;
                    case "Edit":
                        if (result.Contains(commands[1]))
                        {
                            int indexToEdit = result.IndexOf(commands[1]);
                            result[indexToEdit] = commands[2];
                        }
                        break;
                    case "Pin":
                        if (result.Contains(commands[1]))
                        {
                            int indexToEdit = result.IndexOf(commands[1]);
                            result.RemoveAt(indexToEdit);
                            result.Add(commands[1]);
                        }
                        break;
                    case "Spam":
                        commands.RemoveAt(0);
                        result.AddRange(commands);
                        break;
                }

                commands = Console.ReadLine().Split().ToList();
            }

            for (int i = 0; i < result.Count; i++)
            {
                Console.WriteLine(result[i]);
            }
        }
    }
}
