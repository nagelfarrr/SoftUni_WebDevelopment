using System;
using System.Collections.Generic;
using System.Linq;

namespace _02.AverageStudentGrades
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int numberOfStudents = int.Parse(Console.ReadLine());

            List<decimal> grades = new List<decimal>();

            Dictionary<string, List<decimal>> students = new Dictionary<string, List<decimal>>();

            for (int i = 0; i < numberOfStudents; i++)
            {
                string[] input = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
                string studentName = input[0];
                decimal grade = decimal.Parse(input[1]);

                if (!students.ContainsKey(studentName))
                    students.Add(studentName, new List<decimal>());

                students[studentName].Add(grade);
            }

            foreach (var student in students)
            {
                Console.Write($"{student.Key} -> ");
                foreach (var grade in student.Value)
                {
                    Console.Write($"{grade:f2} ");
                }

                Console.Write($"(avg: {student.Value.Average():f2})");
                Console.WriteLine();
            }
        }
    }
}
