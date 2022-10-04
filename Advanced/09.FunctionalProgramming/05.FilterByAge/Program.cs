using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Channels;

namespace _05.FilterByAge
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            List<Person> people = new List<Person>();

            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries);
                string name = input[0];
                int personAge = int.Parse(input[1]);

                people.Add(new Person(name,personAge));

            }

            string condition = Console.ReadLine();
            int age = int.Parse(Console.ReadLine());
            string format = Console.ReadLine();

            Func<Person, bool> filter = CreateFilter(condition, age);
            Action<Person> printer = CreatePrinter(format);
            PrintFilteredPeople(people,filter,printer);
        }
        
         public static Func<Person, bool> CreateFilter(string condition, int ageThreshold)
         {
             if (condition == "younger")
                 return x => x.Age < ageThreshold;
             else
             {
                 return x => x.Age >= ageThreshold;
             }
         }

         public static Action<Person> CreatePrinter(string format)
         {
             switch (format)
             {
                case "name":
                    return x => Console.WriteLine(x.Name);
                case "age":
                    return x => Console.Write(x.Age);
                case "name age":
                    return x => Console.WriteLine($"{x.Name} - {x.Age}");
             }

             return null;
         }

         static void PrintFilteredPeople(List<Person> people, Func<Person, bool> filter, Action<Person> printer)
         {
             var filteredPeople = people.Where(x => filter(x)).ToList();
             foreach (var person in filteredPeople)
             {
                 printer(person);
             }
         }
    }

    class Person
    {
        public Person(string name, int age)
        {
            this.Name = name;
            this.Age = age;
        }

        public string Name { get; set; }
        public int Age { get; set; }
    }

    
}
