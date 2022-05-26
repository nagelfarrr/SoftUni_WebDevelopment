using System;

namespace _05.Messages
{
    class Program
    {
        static void Main(string[] args)
        {
            int input = int.Parse(Console.ReadLine());
            int number = 0;
            int digitCount = 0;

            int[] index = { 2, 3, 4, 5, 6, 7, 8, 9, 0 };
            char[] alphabet = "abcdefghijklmnopqrstuvwxyz".ToCharArray();

            for (int i = 0; i < input; i++)
            {
                number = int.Parse(Console.ReadLine());
                int newNumber = number;
                //This shows us how many times a button is pressed.
                while (number > 0)
                {
                    newNumber = newNumber / 10;
                    digitCount++;
                }
               
            }










        }
    }
}
