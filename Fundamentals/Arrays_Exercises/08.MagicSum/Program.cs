using System;
using System.Linq;
using System.Threading.Channels;

namespace _08.MagicSum
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] arr = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            int magicNum = int.Parse(Console.ReadLine());


            for (int i = 0; i < arr.Length; i++)
            {
                for (int j = i+1; j < arr.Length; j++)
                {
                    if (arr[i] + arr[j] == magicNum)
                    {
                        Console.WriteLine($"{arr[i]} {arr[j]}");
                        
                    }
                }
            }
        }
    }
}
