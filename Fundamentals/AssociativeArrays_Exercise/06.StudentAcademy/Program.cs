using System;
using System.Collections.Generic;
using System.Linq;

namespace _06.StudentAcademy
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int numberOfInputs = int.Parse(Console.ReadLine());
            Dictionary<string, List<double>> studentsAverageGrades = new Dictionary<string, List<double>>();

            for (int i = 0; i < numberOfInputs; i++)
            {
                string studentName = Console.ReadLine();
                double studentGrade = double.Parse(Console.ReadLine());

                if (!studentsAverageGrades.ContainsKey(studentName))
                {
                    studentsAverageGrades[studentName] = new List<double>();


                }
                studentsAverageGrades[studentName].Add(studentGrade);
            }

            foreach (var student in studentsAverageGrades)
            {

                if (student.Value.Average() >= 4.50)
                    Console.WriteLine($"{student.Key} -> {student.Value.Average():f2}");
            }
        }
    }
}
