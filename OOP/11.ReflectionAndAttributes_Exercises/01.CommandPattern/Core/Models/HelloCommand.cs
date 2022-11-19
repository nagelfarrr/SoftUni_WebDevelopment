namespace CommandPattern.Core.Models
{
    using Contracts;

    public class HelloCommand : ICommand
    {
        public string Execute(string[] args) => $"Hello, {args[0]}";

    }
}
