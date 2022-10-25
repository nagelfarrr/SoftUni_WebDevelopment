using System;
using System.Collections.Generic;

namespace CustomStack
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            StackOfStrings stackofstrings = new StackOfStrings();


            Console.WriteLine(stackofstrings.AddRange(new List<string>() { "1", "2", "3", "4" }));
        }
    }
}
