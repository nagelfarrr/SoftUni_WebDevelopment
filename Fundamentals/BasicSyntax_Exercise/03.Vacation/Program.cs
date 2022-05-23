using System;

namespace _03.Vacation
{
    class Program
    {
        static void Main(string[] args)
        {
            int countOfPeople = int.Parse(Console.ReadLine());
            string typeOfGroup = Console.ReadLine();
            string dayOfWeek = Console.ReadLine();

            double priceForOne = 0.0;
            double totalPrice = 0.0;
            switch (typeOfGroup)
            {
                case "Students":
                    switch (dayOfWeek)
                    {
                        case "Friday":
                            priceForOne = 8.45;
                            break;
                        case "Saturday":
                            priceForOne = 9.80;
                            break;
                        case "Sunday":
                            priceForOne = 10.46;
                            break;
                    }
                    totalPrice = countOfPeople * priceForOne;
                    if(countOfPeople >= 30)
                    {
                        totalPrice = totalPrice * 0.85;
                    }

                    break;
                case "Business":
                    switch (dayOfWeek)
                    {
                        case "Friday":
                            priceForOne = 10.90;
                            break;
                        case "Saturday":
                            priceForOne = 15.60;
                            break;
                        case "Sunday":
                            priceForOne = 16;
                            break;
                    }
                    
                    if(countOfPeople >= 100)
                    {
                        countOfPeople -= 10;
                        totalPrice = countOfPeople * priceForOne;
                    }
                    else
                    {
                        totalPrice = countOfPeople * priceForOne;
                    }
                    break;
                case "Regular":
                    switch (dayOfWeek)
                    {
                        case "Friday":
                            priceForOne = 15;
                            break;
                        case "Saturday":
                            priceForOne = 20;
                            break;
                        case "Sunday":
                            priceForOne = 22.50;
                            break;
                    }
                    totalPrice = countOfPeople * priceForOne;
                    if( countOfPeople >=10 && countOfPeople <= 20)
                    {
                        totalPrice = totalPrice * 0.95;
                    }

                    break;
            }
            Console.WriteLine($"Total price: {totalPrice:f2}");

        }
    }
}
