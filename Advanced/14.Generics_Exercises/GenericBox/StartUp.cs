using System;
using System.Linq;

namespace GenericBox
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            int numberOfElements = int.Parse(Console.ReadLine());
            Box<string> box = new Box<string>();
            for (int i = 0; i < numberOfElements; i++)
            {
                string input =Console.ReadLine();

                box.List.Add(input);
            }

            string itemToCompare = Console.ReadLine();

            Console.WriteLine(box.CompareCount(itemToCompare));
        }
    }
}

