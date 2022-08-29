using System;
using System.Collections.Generic;
using System.Linq;

namespace _03.SimpleCalculator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var inputLine = Console.ReadLine();
            var stack = new Stack<string>(inputLine.Split(' ').Reverse());

            while (stack.Count >1)
            {
                var firstNumber = int.Parse(stack.Pop());
                var op = stack.Pop();
                var secondNumber = int.Parse(stack.Pop());

                var currentResult = 0;

                if(op =="+")
                    currentResult = firstNumber+secondNumber;
                else if (op == "-") 
                    currentResult = firstNumber - secondNumber;

                
                stack.Push(currentResult.ToString());
            }

            Console.WriteLine(stack.Peek());
        }
    }
}
