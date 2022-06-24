using System;

namespace _04.SoftUniReception
{
    class Program
    {
        static void Main(string[] args)
        {
            int firstEmployeeEfficiency = int.Parse(Console.ReadLine());
            int secondEmployeeEfficiency = int.Parse(Console.ReadLine());
            int thirdEmployeeEfficiency = int.Parse(Console.ReadLine());

            int numberOfStudents = int.Parse(Console.ReadLine());

            int allEmployees = firstEmployeeEfficiency + secondEmployeeEfficiency + thirdEmployeeEfficiency;
            int timeNeeded = 0;
            int hoursCount = 0;
            while (numberOfStudents > 0)
            {
                hoursCount++;
                timeNeeded++;
                if (hoursCount > 3)
                {
                    hoursCount = 0;
                    
                    numberOfStudents += allEmployees;
                }

                numberOfStudents = numberOfStudents - allEmployees;
            }




            Console.WriteLine($"Time needed: {timeNeeded}h.");
        }
    }
}
