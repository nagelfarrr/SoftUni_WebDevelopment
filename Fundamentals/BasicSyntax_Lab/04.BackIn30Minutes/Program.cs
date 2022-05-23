using System;

namespace _04.BackIn30Minutes
{
    class Program
    {
        static void Main(string[] args)
        {
            int hours = int.Parse(Console.ReadLine());
            int minutes = int.Parse(Console.ReadLine());

            int mm = minutes + 30;
            int hh = hours;
            if(mm > 59)
            {
                hh = hours + 1;
                mm -= 60;
            }
            if(hh> 23)
            {
                hh = 0;
            }

            if (mm < 10)
            {
                Console.WriteLine($"{hh}:0{mm}");
            }
            else
            {
                Console.WriteLine($"{hh}:{mm}");

            }
        }
    }
}
