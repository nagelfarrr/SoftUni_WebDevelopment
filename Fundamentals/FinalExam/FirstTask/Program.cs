using System;
using System.Text;
using System.Transactions;

namespace FirstTask
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string stringInput = Console.ReadLine();

            while (true)
            {
                string[] input = Console.ReadLine().Split(' ');
                if (input[0] == "End") break;


                string cmd = input[0];

                switch (cmd)
                {
                    case "Translate":
                        stringInput = stringInput.Replace(input[1], input[2]); ;
                        
                        Console.WriteLine(stringInput);
                        break;

                    case "Includes":
                        if (stringInput.Contains(input[1]))
                        {
                            Console.WriteLine("True");
                        }
                        else
                        {
                            Console.WriteLine("False");
                        }
                        break;

                    case "Start":
                        if (stringInput.StartsWith(input[1]))
                        {
                            Console.WriteLine("True");
                        }
                        else
                        {
                            Console.WriteLine("False");
                        }

                        break;

                    case "Lowercase":
                        stringInput = stringInput.ToLower();

                        Console.WriteLine(stringInput);
                        break;

                    case "FindIndex":
                        int lastIndex = stringInput.LastIndexOf(input[1]);

                        Console.WriteLine(lastIndex);
                        break;

                    case "Remove":
                        
                        stringInput = stringInput.Remove(int.Parse(input[1]), int.Parse(input[2]));

                        Console.WriteLine(stringInput);
                        break;
                }
            }
        }
        
    }
}
