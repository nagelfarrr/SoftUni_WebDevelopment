using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

namespace _08.AnonymousThreat
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<string> input = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).ToList();

            List<string[]> resultList = new List<string[]>();


            while (true)
            {
                string[] commands = Console.ReadLine().Split(" ");
                if (commands[0] == "3:1") break;

                switch (commands[0])
                {
                    case "merge":
                        int startIndex = int.Parse(commands[1]);
                        int endIndex = int.Parse(commands[2]);
                        string tempString = string.Empty;

                        if (startIndex < 0)
                        {
                            startIndex = 0;
                        }

                        if (endIndex > input.Count)
                        {
                            endIndex = input.Count;
                        }

                        for (int i = startIndex; i < endIndex; i++)
                        {
                            tempString += input[i];
                        }
                        input.RemoveRange(startIndex, endIndex - startIndex);
                        input.Insert(startIndex, tempString);
                        break;

                    case "divide":
                        int index = int.Parse(commands[1]);
                        int partitions = int.Parse(commands[2]);

                        string stringToDivide = input[index];

                        int stringsCount = stringToDivide.Length / partitions;
                        if (stringToDivide.Length % partitions == 0)
                        {
                            for (int i = 0; i < stringToDivide.Length; i++)
                            {
                                
                            }
                        }
                        break;
                }
            }

            Console.WriteLine(string.Join(" ", input));
        }


    }
}