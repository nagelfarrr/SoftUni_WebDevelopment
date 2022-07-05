using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;

namespace _02.OldestFamilyMember
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberOfPeople = int.Parse(Console.ReadLine());
            List<Person> people = new List<Person>();
            var currentFamily = new Family();
            for (int i = 0; i < numberOfPeople; i++)
            {
                string[] input = Console.ReadLine().Split(' ');
                string name = input[0];
                int age = int.Parse(input[1]);

                var person = new Person(name, age);

                currentFamily.AddMember(person);
            }



            var oldestPerson = currentFamily.GetOldestPerson();
            Console.WriteLine($"{oldestPerson.Name} {oldestPerson.Age}");


        }
    }

    public class Person
    {
        public Person(string name, int age)
        {
            this.Name = name;
            this.Age = age;
        }

        public string Name { get; set; }
        public int Age { get; set; }
    }

    public class Family
    {
        public Family()
        {
            this.People = new List<Person>();
        }

        public List<Person> People { get; set; } = new List<Person>();


        public void AddMember(Person person)
        {
            this.People.Add(person);
        }

        public Person GetOldestPerson()
        {
            var oldestPerson = new Person("name", 0);
            oldestPerson = People.OrderByDescending(x => x.Age).FirstOrDefault();

            return oldestPerson;
        }
    }
}
