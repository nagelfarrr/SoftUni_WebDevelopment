using System;

namespace _04.PasswordValidator
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            bool isPasswordLengthValid = ValidPasswordLength(input);
            bool isPasswordCharactersValid = ValidPasswordCharacters(input);
            bool isPasswordDigitCountValid = ValidPasswordDigitCount(input);

            if (ValidPasswordLength(input) && ValidPasswordCharacters(input) && ValidPasswordDigitCount(input))
            {
                Console.WriteLine("Password is valid");
            }

            if (!isPasswordLengthValid)
            {
                Console.WriteLine("Password must be between 6 and 10 characters");
            }

            if (!isPasswordCharactersValid)
            {
                Console.WriteLine("Password must consist only of letters and digits");
            }

            if (!isPasswordDigitCountValid)
            {
                Console.WriteLine("Password must have at least 2 digits");
            }
            
        }

        static bool ValidPasswordLength(string input)
        {
            return input.Length >= 6 && input.Length <= 10;

        }

        static bool ValidPasswordCharacters(string input)
        {
            foreach (char ch in input)
            {
                if (!char.IsLetterOrDigit(ch))
                {
                    return false;
                }
            }
            return true;

        }

        static bool ValidPasswordDigitCount(string input)
        {

            int digitCount = 0;
            for (int i = 0; i < input.Length; i++)
            {
                if (Char.IsDigit(input[i]))
                {
                    digitCount++;
                }
            }

            return digitCount >= 2;
        }
    }
}
