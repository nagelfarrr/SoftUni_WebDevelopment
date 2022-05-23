using System;

namespace _05.Login
{
    class Program
    {
        static void Main(string[] args)
        {
            string username = Console.ReadLine();
            string passwordInput = Console.ReadLine();

            string password = string.Empty;
            int counter = 1;
            for (int i = username.Length -1; i >= 0; i--)
            {
                password += username[i];
            }

            while (passwordInput != password)
            {
                Console.WriteLine("Incorrect password. Try again.");
                passwordInput = Console.ReadLine();
                counter++;
                if(counter == 4)
                {
                    Console.WriteLine($"User {username} blocked!");
                    return;
                }
            }

            Console.WriteLine($"User {username} logged in.");
            
        }
    }
}
