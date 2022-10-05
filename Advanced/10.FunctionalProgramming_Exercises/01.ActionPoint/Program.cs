using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Threading.Channels;

namespace _01.ActionPoint
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Action<string[]> print = str => Console.WriteLine(string.Join(Environment.NewLine, str));
            

            string[] text = Console.ReadLine().Split(" ",StringSplitOptions.RemoveEmptyEntries);

            print(text);
        }
    }
}
