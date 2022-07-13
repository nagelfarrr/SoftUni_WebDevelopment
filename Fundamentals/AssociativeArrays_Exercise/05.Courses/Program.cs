using System;
using System.Collections.Generic;
using System.Linq;

namespace _05.Courses
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, List<string>> courseInformation = new Dictionary<string, List<string>>();

            string input = Console.ReadLine();

            while (input != "end")
            {
                string[] command = input.Split(" :",StringSplitOptions.RemoveEmptyEntries);
                string courseName = command[0];
                string personName = command[1];

                if (!courseInformation.ContainsKey(courseName))
                {

                    courseInformation[courseName] = new List<string>();
                }

                
                courseInformation[courseName].Add(personName);

                input = Console.ReadLine();
            }

            foreach (var course in courseInformation)
            {
                Console.WriteLine($"{course.Key}: {course.Value.Count}");
                for (int i = 0; i < course.Value.Count; i++)
                {
                    Console.WriteLine($"--{course.Value[i]}");
                }
            }
        }
    }
}
