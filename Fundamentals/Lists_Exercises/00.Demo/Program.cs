using System;
using System.Collections.Generic;
using System.Linq;

namespace _00.Demo
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] arr = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 19, 21 };

            Random random = new Random();
            arr = arr.OrderBy(x => random.Next()).ToArray();
            List<int> oddNumbers = new List<int>();
            List<int> evenNumbers = new List<int>();

            PrintOddSequence(arr);
            //rintEvenSequence();


            //Console.WriteLine(string.Join(" ",arr));

        }

        private static void PrintOddSequence(int[] arr)
        {
            List<int> oddSequence = new List<int>();

            int tempNum = 0;
            foreach (var number in arr)
            {
                if (number % 2 != 0)
                {
                    if (tempNum < number)
                    {
                        tempNum = number;
                        oddSequence.Add(tempNum);
                    }
                    else
                    {
                        oddSequence.Clear();
                        oddSequence.Add(number);
                        tempNum = 0;
                    }
                }
                else
                {
                    continue;
                }
            }

            Console.WriteLine(string.Join(" ", oddSequence));

        }
    }
}