using System;
using System.Collections.Generic;
using System.Linq;

namespace _07.OrderByAge
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Person> persons = new List<Person>();
            while (true)
            {
                string input = Console.ReadLine();
                if (input == "End") break;

                string[] personData = input.Split(' ');
                string name = personData[0];
                string id = personData[1];
                int age = int.Parse(personData[2]);

                var person = new Person(name, id, age);
                persons.Add(person);
            }

            var orderedPersons = persons.OrderBy(person => person.Age);

            foreach (var person in orderedPersons)
            {
                Console.WriteLine($"{person.Name} with ID: {person.ID} is {person.Age} years old.");
            }
        }
    }

    public class Person
    {
        public Person(string name, string id, int age)
        {
            this.Name = name;
            this.ID = id;
            this.Age = age;
        }

        public string Name { get; set; }
        public string ID { get; set; }
        public int Age { get; set; }
    }
}
