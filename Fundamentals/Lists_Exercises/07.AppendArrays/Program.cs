using System;
using System.Collections.Generic;
using System.Linq;

namespace _07.AppendArrays
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> firstList = Console.ReadLine()
                .Split("|")
                .ToList();

            List<string> tempList = new List<string>();
            List<string> finalList = new List<string>();
            foreach (var arr in firstList)
            {
                
                tempList = arr.Split(" ",StringSplitOptions.RemoveEmptyEntries).ToList();
                tempList.Reverse();
                finalList.AddRange(tempList);
                

            }
            
            finalList.Reverse();
            Console.WriteLine(string.Join(" ", finalList));
        } 
    }
}
