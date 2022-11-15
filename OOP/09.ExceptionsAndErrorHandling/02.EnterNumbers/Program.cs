using System;

namespace _02.EnterNumbers
{
    using System.Collections.Generic;
    using System.Linq;

    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> numsCollection = new List<int>();
            while (numsCollection.Count < 10)
            {
                try
                {
                    if (!numsCollection.Any())
                        numsCollection.Add(ReadNumber(1, 100));
                    else
                        numsCollection.Add(ReadNumber(numsCollection.Max(), 100));
                }
                catch (FormatException formatEx)
                { Console.WriteLine(formatEx.Message); }
                catch (ArgumentException argEx)
                { Console.WriteLine(argEx.Message); }
            }
            Console.WriteLine(String.Join(", ", numsCollection));
        }

        static int ReadNumber(int start, int end)
        {
            string input = Console.ReadLine();
            int num;
            try
            { num = int.Parse(input); }
            catch (FormatException)
            { throw new FormatException("Invalid Number!"); }

            if (num <= start || num >= end)
            { throw new ArgumentException($"Your number is not in range {start} - {end}!"); }

            return num;
        }
    }
}
