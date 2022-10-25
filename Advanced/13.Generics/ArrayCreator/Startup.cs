using System;

namespace GenericArrayCreator
{
    public class Startup
    {
       public static void Main(string[] args)
        {
            string[] strings = GenericArrayCreator.ArrayCreator.Create(5, "Pesho");
            int[] integers = GenericArrayCreator.ArrayCreator.Create(10, 33);


            Console.WriteLine(string.Join(", ", strings));
            Console.WriteLine(string.Join(", ", integers));

        }
    }
}
