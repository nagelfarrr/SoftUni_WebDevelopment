using System;
using System.Linq;

namespace _08.CondenseArrayToNumber
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] arr = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            int condensedLength = 0;

            for (int i = 0; i < arr.Length -1; i++)
            {
                condensedLength++;
            }

            int[] condensedArray = new int[condensedLength];
            while (arr.Length > 1)
            {

                for (int i = 0; i < arr.Length - 1; i++)
                {
                    condensedArray[i] = arr[i] + arr[i + 1];

                    if (i == arr.Length - 2)
                    {
                        arr = condensedArray;
                        condensedArray = new int[arr.Length - 1];
                    }

                }
            }
            
            Console.WriteLine(arr[0]);
        }
    }
}
