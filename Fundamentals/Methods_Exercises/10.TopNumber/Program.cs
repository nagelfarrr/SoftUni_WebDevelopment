using System;
using System.Linq;
using System.Net;

namespace _10.TopNumber
{
    class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());
            IsSumDivisible(number);
        }


        static void IsSumDivisible(int number)
        {
            int divislbeNumber = 0;
            int[] numbersArray = new int[0];
            for (int i = 1; i <= number; i++)
            {
                int tempNumber = i;



                if (tempNumber % 8 == 0)
                {
                    divislbeNumber = tempNumber;

                    for (int j = 0; j < numbersArray.Length+1; j++)
                    {
                        int[] newArray = new int[j+1];
                        newArray[j] = divislbeNumber;
                        numbersArray = newArray;
                    }

                }


            }


        }

    }
}
