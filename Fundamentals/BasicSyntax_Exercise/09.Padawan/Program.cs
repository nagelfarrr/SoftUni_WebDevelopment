using System;

namespace _09.Padawan
{
    class Program
    {
        static void Main(string[] args)
        {
            double money = double.Parse(Console.ReadLine());
            int students = int.Parse(Console.ReadLine());
            double lightsaberPrice = double.Parse(Console.ReadLine());
            double robePrice = double.Parse(Console.ReadLine());
            double beltPrice = double.Parse(Console.ReadLine());
            int beltQty = students;

            double totalLightsaberPrice = Math.Ceiling(students + 0.1 * students) * lightsaberPrice;
            
            double totalRobePrice = robePrice * students;
            for (int i = 1; i <= students; i++)
            {
                if(i%6 == 0)
                {
                    beltQty--;
                }
            }
            double totalBeltPrice = beltQty * beltPrice;

            double totalPrice = (totalLightsaberPrice) + totalBeltPrice + totalRobePrice;

            if(totalPrice<= money)
            {
                Console.WriteLine($"The money is enough - it would cost {totalPrice:f2}lv.");
            }
            else
            {
                
                Console.WriteLine($"John will need {(totalPrice-money):f2}lv more.");
            }
        }
    }
}
