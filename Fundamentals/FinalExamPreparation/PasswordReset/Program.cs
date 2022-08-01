using System;

namespace PasswordReset
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string password = Console.ReadLine();

            while (true)
            {
                string input = Console.ReadLine();
                if (input == "Done") break;
                string[] commands = input.Split(' ');
                string action = commands[0];

                switch (action)
                {
                    case "TakeOdd":
                        string tempPassword = string.Empty;
                        for (int i = 0; i < password.Length; i++)
                        {
                            if (i % 2 != 0)
                            {
                                tempPassword += password[i];
                            }
                            
                        }

                        password = tempPassword;
                        Console.WriteLine(password);
                        break;
                    case "Cut":
                        
                        int index = int.Parse(commands[1]);
                        int length = int.Parse(commands[2]);
                        string substring = password.Substring(index, length);

                        if (password.Contains(substring))
                        {
                            password = password.Remove(index, length);
                        }
                        Console.WriteLine(password);
                        break;
                    case "Substitute":
                        string substringToReplace = commands[1];
                        string substitute = commands[2];

                        if (password.Contains(substringToReplace))
                        {
                            password = password.Replace(substringToReplace, substitute);
                            Console.WriteLine(password);
                        }
                        else
                        {
                            Console.WriteLine("Nothing to replace!");
                        }
                        break;
                }
            }

            Console.WriteLine($"Your password is: {password}");
        }
    }
}
