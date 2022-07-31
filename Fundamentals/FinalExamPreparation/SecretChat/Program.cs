using System;
using System.Linq;
using Microsoft.VisualBasic;

namespace SecretChat
{
    class Program
    {
        static void Main(string[] args)
        {
            string concealedMessage = Console.ReadLine();

            while (true)
            {
                string input = Console.ReadLine();
                if (input == "Reveal") break;
                string[] commands = input.Split(":|:", StringSplitOptions.RemoveEmptyEntries);

                switch (commands[0])
                {
                    case "InsertSpace":
                        int index = int.Parse(commands[1]);
                        concealedMessage = InsertSpace(concealedMessage, index);
                        break;
                    case "Reverse":
                        string substring = commands[1];
                        concealedMessage = ReverseAString(concealedMessage, substring);
                        break;
                    case "ChangeAll":
                        string substringToReplace = commands[1];
                        string replacementText = commands[2];

                        concealedMessage = ChangeAll(concealedMessage, substringToReplace, replacementText);
                        break;
                }
            }

            Console.WriteLine($"You have a new text message: {concealedMessage}");
        }

        private static string InsertSpace(string concealedMessage, int index)
        {
            concealedMessage = concealedMessage.Insert(index, " ");
            Console.WriteLine(concealedMessage);
            return concealedMessage;
        }

        private static string ReverseAString(string concealedMessage, string substring)
        {
            if (concealedMessage.Contains(substring))
            {
                int startingIndex = concealedMessage.IndexOf(substring);
                concealedMessage = concealedMessage.Remove(startingIndex, substring.Length);
                substring = Reverse(substring);
                concealedMessage = $"{concealedMessage}{substring}";
                Console.WriteLine(concealedMessage);
            }
            else
            {
                Console.WriteLine("error");
            }

            return concealedMessage;
        }

        private static string ChangeAll(string concealedMessage, string substringToReplace, string replacementText)
        {
            while (concealedMessage.Contains(substringToReplace))
            {
                concealedMessage = concealedMessage.Replace(substringToReplace, replacementText);
            }

            Console.WriteLine(concealedMessage);
            return concealedMessage;
        }

        static string Reverse(string substring)
        {
            char[] array = substring.ToCharArray();
            Array.Reverse(array);
            return new String(array);
        }
    }
}
