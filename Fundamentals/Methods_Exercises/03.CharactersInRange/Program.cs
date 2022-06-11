using System;
using System.Linq;

namespace _03.CharactersInRange
{
    class Program
    {
        static void Main(string[] args)
        {
            char char1 = char.Parse(Console.ReadLine());
            char char2= char.Parse(Console.ReadLine());
            PrintMidCharacters(char1, char2);
        }

        static void PrintMidCharacters(char char1, char char2)
        {
            if (char2 < char1)
            {
                (char1, char2) = (char2, char1);
            }
            
            for (int i = char1 +1 ; i < char2; i++)
            {
                char newchar = (char)i;
                Console.Write(newchar + " ");
            }
        }
    }
}
