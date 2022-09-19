using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _09.SimpleTextEditor
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int numberOfOperations = int.Parse(Console.ReadLine());
            Stack<string> text = new Stack<string>();
            text.Push(string.Empty);
            

            for (int i = 0; i < numberOfOperations; i++)
            {
                string input = Console.ReadLine();
                string cmd = input.Split().First();
                string item = input.Split().Last();

                switch (cmd)
                {
                    case "1":
                        text.Push(text.Peek() + item);
                        break;
                    case "2":
                        int count = int.Parse(item);
                        string newText = text.Peek().Remove(text.Peek().Length - count);
                        text.Push(newText);
                        break;
                    case "3":
                        int index = int.Parse(item) - 1;
                        Console.WriteLine(text.Peek()[index]);
                        break;
                    case "4":
                        text.Pop();
                        break;
                }

            }
        }
    }
}
