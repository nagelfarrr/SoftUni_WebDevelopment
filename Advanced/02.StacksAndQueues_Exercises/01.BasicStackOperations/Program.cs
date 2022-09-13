using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace _01.BasicStackOperations
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //input
            int[] commandNumbers = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse).ToArray();

            int[] numbers = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse).ToArray();

            //declaration
            int elementsToPush = commandNumbers[0];
            int elementsToPop = commandNumbers[1];
            int numberToFind = commandNumbers[2];

            Stack<int> stack = new Stack<int>();

            Push(stack, elementsToPush, numbers);

            Pop(stack, elementsToPop);

            if(stack.Contains(numberToFind))
                Console.WriteLine("true");
            else
            {
                if (stack.Count > 0)
                {
                    Console.WriteLine(stack.Min());
                }
                else
                {
                    Console.WriteLine(stack.Count);
                }
            }


        }

        static void Push(Stack<int> stack, int elementsToPush, int[] numbers)
        {
            for (int i = 0; i < elementsToPush; i++)
            {
                stack.Push(numbers[i]);
            }
        }

        static void Pop(Stack<int> stack, int elementsToPop)
        {
            for (int i = 0; i < elementsToPop; i++)
            {
                stack.Pop();
            }
        }
    }
}
