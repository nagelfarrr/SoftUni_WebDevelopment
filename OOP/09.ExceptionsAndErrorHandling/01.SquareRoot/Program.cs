using System;

namespace _01.SquareRoot
{
    internal class Program
    {
        static void Main(string[] args)
        {
           
            try
            {
                int number = int.Parse(Console.ReadLine());

                if (number < 0)
                {
                    throw new ArgumentException("Invalid number.");
                }


                Console.WriteLine(Math.Sqrt(number));
            }
            catch (ArgumentException ae)
            {

                Console.WriteLine(ae.Message);
            }
            

            Console.WriteLine("Goodbye.");
        }
    }
}
