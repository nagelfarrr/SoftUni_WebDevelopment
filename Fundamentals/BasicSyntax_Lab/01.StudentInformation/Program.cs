using System;

namespace _01.StudentInformation
{
    class Program
    {
        static void Main(string[] args)
        {
            string studenName = Console.ReadLine();
            int studentAge = int.Parse(Console.ReadLine());
            double averageGrade = double.Parse(Console.ReadLine());

            Console.WriteLine($"Name: {studenName}, Age: {studentAge}, Grade: {averageGrade:f2}");
        }
    }
}
