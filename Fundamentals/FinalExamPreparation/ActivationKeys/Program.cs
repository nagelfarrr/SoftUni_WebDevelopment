using System;

namespace ActivationKeys
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string rawKey = Console.ReadLine();
            string activationKey = rawKey;
            while (true)
            {
                string input = Console.ReadLine();
                if (input == "Generate") break;
                string[] commands = input.Split(">>>", StringSplitOptions.RemoveEmptyEntries);
                string cmd = commands[0];

                switch (cmd)
                {
                    case "Contains":
                        string substring = commands[1];
                        if (rawKey.Contains(substring))
                        {
                            Console.WriteLine($"{rawKey} contains {substring}");
                        }
                        else
                        {
                            Console.WriteLine("Substring not found!");
                        }
                        break;
                    case "Flip":
                        string upperOrLower = commands[1];
                        int startIndex = int.Parse(commands[2]);
                        int endIndex = int.Parse(commands[3]);

                        switch (upperOrLower)
                        {
                            case "Upper":
                                string tempToUpper = rawKey.Substring(startIndex, endIndex - startIndex);
                                rawKey = rawKey.Replace(tempToUpper, tempToUpper.ToUpper());
                                Console.WriteLine(rawKey);
                                break;

                            case "Lower":
                                string tempToLower = rawKey.Substring(startIndex, endIndex - startIndex);
                                rawKey = rawKey.Replace(tempToLower, tempToLower.ToLower());
                                Console.WriteLine(rawKey);
                                break;
                        }

                        break;
                    case "Slice":
                        int startIndexToSlice = int.Parse(commands[1]);
                        int endIndexToSlice = int.Parse(commands[2]);

                        rawKey = rawKey.Remove(startIndexToSlice, endIndexToSlice - startIndexToSlice);
                        Console.WriteLine(rawKey);
                        break;
                }
            }

            Console.WriteLine($"Your activation key is: {rawKey}");
        }
    }
}
