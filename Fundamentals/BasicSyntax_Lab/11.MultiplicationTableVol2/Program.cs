using System;

namespace _11.MultiplicationTableVol2
{
    class Program
    {
        static void Main(string[] args)
        {
            int input = int.Parse(Console.ReadLine());
            int interval = int.Parse(Console.ReadLine());

            for (int i = interval; i <= 10; i++)
            {
                Console.WriteLine($"{input} X {i} = {input * i}");
            }
            if(interval > 10)
            {
                Console.WriteLine($"{input} X {interval} = {input * interval}");
            }
        }
    }
}
