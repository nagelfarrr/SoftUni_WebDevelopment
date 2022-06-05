using System;
using System.Linq;

namespace _02.CommonElements
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] firstArray = Console.ReadLine()
                .Split()
                .ToArray();
            string[] secondArray = Console.ReadLine()
                .Split()
                .ToArray();

            foreach (var currentElement in firstArray)
            {
                for (int i = 0; i < secondArray.Length; i++)
                {
                    string secondCurrentElement = secondArray[i];
                    if (currentElement == secondCurrentElement)
                    {
                        Console.Write($"{currentElement} ");
                        break;

                    }
                }
            }
        }
    }
}
