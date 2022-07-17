using System;

namespace _03.Substring
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string firstInput = Console.ReadLine();
            string secondInput = Console.ReadLine();

            while (secondInput.Contains(firstInput))
            {
                secondInput = secondInput.Replace(firstInput, string.Empty);
            }
            Console.WriteLine(secondInput);
        }
    }
}
