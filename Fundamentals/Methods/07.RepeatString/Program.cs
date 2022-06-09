using System;
using System.Linq;
namespace _07.RepeatString
{
    class Program
    {
        static void Main(string[] args)
        {
            string str = Console.ReadLine();
            int repeat = int.Parse(Console.ReadLine());
            Console.WriteLine(RepeatString(str, repeat));

        }

        static string RepeatString(string str, int repeat)
        {
            string result = string.Concat(Enumerable.Repeat(str, repeat));
            
            return result;
        }
    }
}
