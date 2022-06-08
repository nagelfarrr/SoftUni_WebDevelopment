using System;

namespace _02.PascalTriangle
{
    class Program
    {
        static void Main(string[] args)
        {
            int rows = int.Parse(Console.ReadLine());

            for (int i = 1; i <= rows; i++)
            {
                int[] arr = new int[i];
                arr[0] = 1;
                for (int j = 0; j < arr.Length; j++)
                {
                    int[] arr1 = new int[j+i];
                    Console.WriteLine(string.Join(" ", arr));
                }
                
            }
        }
    }
}
