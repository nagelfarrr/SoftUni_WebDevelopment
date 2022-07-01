using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace _04.Students
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Student> students = new List<Student>();

            string[] input = Console.ReadLine().Split();

            while (input[0] != "end")
            {
                Student student = new Student();

                student.FirstName = input[0];
                student.LastName = input[1];
                student.Age = int.Parse(input[2]);
                student.HomeTown = input[3];

                students.Add(student);

                input = Console.ReadLine().Split();
            }

            string cityName = Console.ReadLine();
            foreach (var student in students)
            {
                if(student.HomeTown == cityName) Console.WriteLine($"{student.FirstName} {student.LastName} is {student.Age} years old.");
            }
        }
    }


    public class Student
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public int Age { get; set; }

        public string HomeTown { get; set; }

    }
}
