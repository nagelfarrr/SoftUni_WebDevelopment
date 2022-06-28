using System;
using System.Collections.Generic;
using System.Linq;

namespace _08.AnonymousThreat
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<string> dataList = Console.ReadLine()
                .Split()
                .ToList();

            string[] commands = Console.ReadLine()
                .Split()
                .ToArray();
            while (commands[0] != "3:1")
            {
                switch (commands[0])
                {
                    case "merge":
                        int startIndex = int.Parse(commands[1]);
                        int endIndex = int.Parse(commands[2]);
                        Merge(dataList, startIndex, endIndex);
                        break;

                    case "divide":
                        int index = int.Parse(commands[1]);
                        int partitions = int.Parse(commands[2]);
                        Divide(dataList, index, partitions);
                        break;
                }

                commands = Console.ReadLine()
                    .Split()
                    .ToArray();
            }

            Console.WriteLine(string.Join(" ", dataList));

        }

        static List<string> Merge(List<string> dataList, int startIndex, int endIndex)
        {
            string newString = String.Empty;
            if (endIndex > dataList.Count) endIndex = dataList.Count;

            for (int i = startIndex; i < endIndex; i++)
            {
                
                newString += dataList[i];
            }

            dataList.RemoveRange(startIndex, endIndex - startIndex);
            dataList.Insert(startIndex, newString);
            return dataList;
        }

        static List<string> Divide(List<string> dataList, int index, int partitions)
        {
            string newString = dataList[index];
            string[] dividedString = new string[partitions];
            char[] charArray = newString.ToCharArray();
            for (int i = 0; i < dividedString.Length; i++)
            {
                string temp = newString.Substring(i, dataList[index].Length/partitions);
                

                dividedString[i] = temp;
            }
            dataList.RemoveAt(index);
            dataList.AddRange(dividedString);
            return dataList;
        }
    }
}