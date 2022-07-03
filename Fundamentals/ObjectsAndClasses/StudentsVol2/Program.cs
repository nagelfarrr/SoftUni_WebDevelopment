using System;
using System.Collections.Generic;
using System.Globalization;
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
                if (IsStudentExisting(input[0], input[1], students))
                {
                    Student student = students.Find(student => student.FirstName == input[0] && student.LastName == input[1]);
                    student.Age = int.Parse(input[2]);
                    student.HomeTown = input[3];
                }
                else
                {
                    Student student = new Student(input[0], input[1], int.Parse(input[2]), input[3]);

                    students.Add(student);
                }

                input = Console.ReadLine().Split();
            }

            string cityName = Console.ReadLine();
            foreach (var student in students)
            {
                if (student.HomeTown == cityName) Console.WriteLine($"{student.FirstName} {student.LastName} is {student.Age} years old.");
            }

            static bool IsStudentExisting(string firstName, string lastName, List<Student> students)
            {
                foreach (var student in students)
                {
                    if (student.FirstName == firstName && student.LastName == lastName) return true;
                }

                return false;
            }
        }
    }


    public class Student
    {
        public Student(string firstName, string lastName, int age, string homeTown)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Age = age;
            this.HomeTown = homeTown;
        }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public int Age { get; set; }

        public string HomeTown { get; set; }

    }
}