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
            if (endIndex > dataList.Count - 1 || endIndex < 0) endIndex = dataList.Count - 1;
            if (startIndex < 0 || startIndex > dataList.Count - 1) startIndex = 0;

            string newString = String.Empty;
            

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
           // if (index > dataList.Count - 1 || index < 0) index = dataList.Count - 1;
           // if (index < 0 || index > dataList.Count - 1) index = 0;
            string newString = dataList[index];
            int chunkSize = newString.Length / partitions;
            var dividedList = new List<string>();
            for (int i = 0; i < partitions; i++)
            {
                if (i == partitions - 1)
                {
                    dividedList.Add(newString.Substring(i * chunkSize));
                }
                else
                {
                    dividedList.Add(newString.Substring(i * chunkSize, chunkSize));
                }
            }
            dataList.RemoveAt(index);
            dataList.InsertRange(index, dividedList);
            return dataList;
        }

       
    }
}