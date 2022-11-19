﻿namespace CommandPattern.Core.Models
{
    using System;
    using CommandPattern.Core.Contracts;

    public class Engine : IEngine
    {
        private readonly ICommandInterpreter commandInterpreter;

        public Engine(ICommandInterpreter commandInterpreter)
        {
            this.commandInterpreter = commandInterpreter;
        }

        public void Run()
        {
            string input = Console.ReadLine();
            string result = this.commandInterpreter.Read(input);

            Console.WriteLine(result);
        }
    }
}
