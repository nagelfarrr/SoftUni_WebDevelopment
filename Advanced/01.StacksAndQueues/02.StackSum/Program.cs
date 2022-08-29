using System;
using System.Collections.Generic;
using System.Linq;

namespace _02.StackSum
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine().Split(" ").Select(int.Parse).ToArray();

            var stack = new Stack<int>(numbers);
            string input = Console.ReadLine();

            while (input.ToLower()!= "end")
            {
                string[] cmds = input.Split(" ");
                string command = cmds[0].ToLower();

                switch (command)
                {
                    case "add":
                        //Pushes two numbers into the stack
                        stack.Push(int.Parse(cmds[1]));
                        stack.Push(int.Parse(cmds[2]));
                        break;

                    case "remove":
                        //Removes the n elements from hte stack if the stack holds more than n elements
                        if (stack.Count > int.Parse(cmds[1]))
                        {
                            for (int i = 0; i < int.Parse(cmds[1]); i++)
                            {
                                stack.Pop();
                            }
                        }

                        break;
                }

                input = Console.ReadLine();
            }

            Console.WriteLine($"Sum: {stack.Sum()}");
        }
    }
}
