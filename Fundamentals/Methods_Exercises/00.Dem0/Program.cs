using System;

namespace Add_Bags
{
    class Program
    {
        static void Main(string[] args)
        {
            int hight = int.Parse(Console.ReadLine());
            int length = int.Parse(Console.ReadLine());
            int percentage = int.Parse(Console.ReadLine());

            const int walls = 4;
            int totalCover = 0;

            totalCover = hight * length * walls;
            totalCover -= (percentage / 100);
            
            while (true)
            {
                string line = Console.ReadLine();
                if (line == "Tired!")
                {
                    int count = int.Parse(line);

                    totalCover -= count;
                    
                }

            }

            Console.WriteLine(totalCover);


        }
    }
}