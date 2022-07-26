using System;

namespace _01.TheImitationGame
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string encryptedMessage = Console.ReadLine();

            while (true)
            {
                string input = Console.ReadLine();
                if (input == "Decode") break;
                string[] operations = input.Split('|');
                string operation = operations[0];

                switch (operation)
                {
                    case "Move":
                        encryptedMessage = Move(operations, encryptedMessage);

                        break;
                    case "Insert":
                        encryptedMessage = Insert(operations, encryptedMessage);
                        break;
                    case "ChangeAll":
                        encryptedMessage = ChangeAll(encryptedMessage, operations);
                        break;
                }
            }

            Console.WriteLine($"The decrypted message is: {encryptedMessage}");
        }

        static string Move(string[] operations, string encryptedMessage)
        {
            int numberOfLettersToMove = int.Parse(operations[1]);
            string stringToMove = encryptedMessage.Substring(0, numberOfLettersToMove);

            encryptedMessage = encryptedMessage.Remove(0, numberOfLettersToMove);
            encryptedMessage += stringToMove;
            return encryptedMessage;
        }


        static string Insert(string[] operations, string encryptedMessage)
        {
            int indexToInsert = int.Parse(operations[1]);
            string valueToInsert = operations[2];
            encryptedMessage = encryptedMessage.Insert(indexToInsert, valueToInsert);
            return encryptedMessage;
        }

        static string ChangeAll(string encryptedMessage, string[] operations)
        {
            string substringToChange = operations[1];
            string stringToReplace = operations[2];

            encryptedMessage = encryptedMessage.Replace(substringToChange, stringToReplace);
            return encryptedMessage;
        }
    }
}
