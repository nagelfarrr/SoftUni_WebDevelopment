using System;
using System.Collections.Generic;
using System.Linq;


namespace _06.MoneyTransaction
{
    internal class Program
    {
        static void Main()
        {
            var accountBalances = new Dictionary<int, double>();
            string[] tokens = Console.ReadLine().Split(',');
            for (int i = 0; i < tokens.Length; i++)
            {
                int account = int.Parse(tokens[i].Split('-').First());
                double balance = double.Parse(tokens[i].Split('-').Last());
                accountBalances.Add(account, balance);
            }
            string input;
            while ((input = Console.ReadLine()) != "End")
            {
                try
                {
                    string[] cmd = input.Split();
                    string command = cmd[0];
                    if (command != "Deposit" && command != "Withdraw")
                        throw new ArgumentException("Invalid command!");

                    int account;
                    try
                    {
                        account = int.Parse(cmd[1]);
                        if (!accountBalances.Keys.Contains(account))
                            throw new FormatException();
                    }
                    catch (FormatException)
                    { throw new ArgumentException("Invalid account!"); }

                    double money = double.Parse(cmd[2]);
                    if (command == "Deposit") accountBalances[account] += money;
                    else if (command == "Withdraw")
                    {
                        if (money > accountBalances[account])
                            throw new ArgumentException("Insufficient balance!");
                        accountBalances[account] -= money;
                    }

                    Console.WriteLine($"Account {account} has new balance: {accountBalances[account]:f2}");
                }
                catch (ArgumentException ex)
                { Console.WriteLine(ex.Message); }
                Console.WriteLine("Enter another command");
            }
        }
    }
}