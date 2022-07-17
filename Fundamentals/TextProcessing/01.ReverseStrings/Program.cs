using System;
using System.Collections.Generic;
using System.Linq;

namespace _01.ReverseStrings
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
           
            while (input != "end")
            {
                string reversed = string.Join("", input.ToCharArray().Reverse());

                Console.WriteLine($"{input} = {reversed}");
                input = Console.ReadLine();
            }

            
        }
    }
}
