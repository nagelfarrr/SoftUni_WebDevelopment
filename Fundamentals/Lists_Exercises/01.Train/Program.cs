using System;
using System.Collections.Generic;
using System.Linq;

namespace _01.Train
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> train = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToList();
            int wagonCapacity = int.Parse(Console.ReadLine());

            while (true)
            {
                string input = Console.ReadLine();
                if (input == "end") break;
                int token = 0;
                string[] command = input.Split();
                if (command[0] == "Add")
                {
                    token = int.Parse(command[1]);
                    train.Add(token);
                }
                else
                {
                    AddPassengers(train, wagonCapacity, token, command);
                }
            }

            Console.WriteLine(string.Join(" ", train));
        }

        static void AddPassengers(List<int> train, int wagonCapacity, int token, string[] command)
        {
            token = int.Parse(command[0]);
            for (int i = 0; i < train.Count; i++)
            {
                if (train[i] + token <= wagonCapacity)
                {
                    train[i] = train[i] + token;
                    break;
                }

            }
        }

    }
}
