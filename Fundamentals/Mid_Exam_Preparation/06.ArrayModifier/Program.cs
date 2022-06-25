using System;
using System.Collections.Generic;
using System.Linq;


namespace _06.ArrayModifier
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToList();

            string[] input = Console.ReadLine()
                .Split();
            
            while (true)
            {

                string command = input[0];

                if (command == "end")
                {
                    Console.WriteLine(string.Join(", ", numbers));
                    break;
                }

                switch (command)
                {
                    case "swap":
                        int firstIndex = int.Parse(input[1]);
                        int secondIndex = int.Parse(input[2]);
                        Swap(numbers, firstIndex, secondIndex);
                        break;
                    case "multiply":
                        int indexOne = int.Parse(input[1]);
                        int indexTwo = int.Parse(input[2]);
                        Multiply(numbers, indexOne, indexTwo);
                        break;
                    case "decrease":
                        Decrease(numbers);
                        break;
                }

                input = Console.ReadLine().Split();

            }
        }

        static void Decrease(List<int> numbers)
        {
            for (int i = 0; i < numbers.Count; i++)
            {
                numbers[i]--;
            }
        }

        static void Multiply(List<int> numbers, int firstIndex, int secondIndex)
        {
            int multipliedNumber = numbers[firstIndex] * numbers[secondIndex];
            numbers[firstIndex] = multipliedNumber;
        }

        static void Swap(List<int> numbers, int firstIndex, int secondIndex)
        {
            
            (numbers[firstIndex], numbers[secondIndex]) = (numbers[secondIndex], numbers[firstIndex]);

        }
    }
}
