using System;


namespace _09.PalindromeIntegers
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            IsNumberPalindrome(input);
        }

        static void IsNumberPalindrome(string input)
        {
            while (input != "END")
            {
                char[] inputArray = input.ToCharArray();
                bool isEqual = false;

                for (int i = 0; i < inputArray.Length; i++)
                {
                    Array.Reverse(inputArray);
                    if (input[i] == inputArray[i])
                    {
                        isEqual = true;
                    }
                    else
                    {
                        isEqual = false;
                        break;
                    }

                }

                if (isEqual)
                {
                    Console.WriteLine("true");
                }
                else
                {
                    Console.WriteLine("false");
                }
                input = Console.ReadLine();
            }
        }
    }
}
