using System;
using System.Linq;

namespace _10.LowerOrUpper
{
    class Program
    {
        static void Main(string[] args)
        {
            char charInput = char.Parse(Console.ReadLine());

            

            if (Char.IsUpper(charInput))
            {
                Console.WriteLine("upper-case");
            }
            else
            {
                Console.WriteLine("lower-case");
            }
        }
    }
}
