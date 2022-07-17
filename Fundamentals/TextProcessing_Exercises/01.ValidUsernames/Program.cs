using System;
using System.Linq;

namespace _01.ValidUsernames
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] usernames = Console.ReadLine().Split(", ");
            ;

            foreach (var username in usernames)
            {

                if (username.Length >= 3 && username.Length <= 16)
                {
                    bool isValid = true;
                    for (int i = 0; i < username.Length; i++)
                    {
                        char currentChar = username[i];

                        if (!(username.Contains('-') || username.Contains('_') || char.IsLetterOrDigit(currentChar)))
                        {
                            isValid = false;
                            break;
                        }
                    }
                    if (isValid) Console.WriteLine(username);
                }

            }
        }
    }
}
