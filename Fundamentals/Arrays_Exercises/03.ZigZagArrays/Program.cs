using System;
using System.Linq;

namespace _03.ZigZagArrays
{
    class Program
    {
        static void Main(string[] args)
        {
            int index = int.Parse(Console.ReadLine());

            int[] arr1 = new int[index];
            int[] arr2 = new int[index];

            for (int i = 0; i < index; i++)
            {
                int[] input = Console.ReadLine().Split().Select(int.Parse).ToArray();

                if (i % 2 == 0)
                {
                    arr1[i] = input[1];
                    arr2[i] = input[0];
                }
                else
                {
                    arr1[i] = input[0];
                    arr2[i] = input[1];
                }


            }

            Console.WriteLine(string.Join(" ", arr2));
            Console.WriteLine(string.Join(" ", arr1));




        }
    }
}
