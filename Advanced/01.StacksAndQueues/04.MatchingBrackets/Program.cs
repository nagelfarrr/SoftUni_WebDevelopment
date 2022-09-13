using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace _04.MatchingBrackets
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string expressionInput = Console.ReadLine();

            Stack<int> stack = new Stack<int>();

            for (int i = 0; i < expressionInput.Length; i++)
            {
                if (expressionInput[i] == '(')
                {
                    stack.Push(i);
                }

                if (expressionInput[i] == ')')
                {
                    int startIndex = stack.Pop();
                    int endIndex = i;
                    Console.WriteLine(expressionInput.Substring(startIndex, endIndex - startIndex + 1));
                }
            }
        }
    }
}
