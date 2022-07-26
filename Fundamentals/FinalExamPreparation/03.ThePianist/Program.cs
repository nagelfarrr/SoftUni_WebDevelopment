using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;

namespace _03.ThePianist
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int numberOfPieces = int.Parse(Console.ReadLine());

            
            Dictionary<string, Dictionary<string, string>> piecesInformation = new Dictionary<string, Dictionary<string, string>>();

            SetInitialPieces(numberOfPieces, piecesInformation);


            while (true)
            {
                string input = Console.ReadLine();
                if (input == "Stop") break;
                string[] commands = input.Split('|');
                string cmd = commands[0];
                

                switch (commands[0])
                {
                    case "Add":
                        AddPiece(piecesInformation, commands);
                        break;
                    case "Remove":
                        RemovePiece(piecesInformation, commands);
                        break;
                    case "ChangeKey":
                        ChangeKey(piecesInformation, commands);
                        break;
                }


            }

            foreach (var piece in piecesInformation)
            {
                Console.Write($"{piece.Key} -> ");
                foreach (var composerAndKey in piece.Value)
                {
                    Console.WriteLine($"Composer: {composerAndKey.Key}, Key: {composerAndKey.Value}");
                }
            }
        }

        static void ChangeKey(Dictionary<string, Dictionary<string, string>> piecesInformation, string[] commands)
        {
            if (!piecesInformation.ContainsKey(commands[1]))
            {
                Console.WriteLine($"Invalid operation! {commands[1]} does not exist in the collection.");
            }
            else
            {
                string dictionaryKey = piecesInformation[commands[1]].Keys.First();
                piecesInformation[commands[1]][dictionaryKey] = commands[2];

                Console.WriteLine($"Changed the key of {commands[1]} to {commands[2]}!");
            }
        }

        static void RemovePiece(Dictionary<string, Dictionary<string, string>> piecesInformation, string[] commands)
        {
            if (!piecesInformation.ContainsKey(commands[1]))
            {
                Console.WriteLine($"Invalid operation! {commands[1]} does not exist in the collection.");
            }
            else
            {
                piecesInformation.Remove(commands[1]);
                Console.WriteLine($"Successfully removed {commands[1]}!");
            }
        }

        static void AddPiece(Dictionary<string, Dictionary<string, string>> piecesInformation, string[] commands)
        {
            if (piecesInformation.ContainsKey(commands[1]))
            {
                Console.WriteLine($"{commands[1]} is already in the collection!");
            }
            else
            {
                piecesInformation[commands[1]] = new Dictionary<string, string>();
                piecesInformation[commands[1]].Add(commands[2], commands[3]);
                Console.WriteLine($"{commands[1]} by {commands[2]} in {commands[3]} added to the collection!");
            }
        }

        static void SetInitialPieces(int numberOfPieces, Dictionary<string, Dictionary<string, string>> piecesInformation)
        {
            for (int i = 0; i < numberOfPieces; i++)
            {
                string[] input = Console.ReadLine().Split('|');

                if (!piecesInformation.ContainsKey(input[0]))
                {
                    piecesInformation[input[0]] = new Dictionary<string, string>();
                }

                piecesInformation[input[0]][input[1]] = input[2];
            }
        }
    }
}
