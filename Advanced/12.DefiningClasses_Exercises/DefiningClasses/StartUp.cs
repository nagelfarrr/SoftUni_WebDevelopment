using System;
using System.Collections.Generic;
using System.Linq;

namespace DefiningClasses
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            Family family = new Family();

            List<Person> olderPeople = new List<Person>();
            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string name = input[0];
                int age = int.Parse(input[1]);

                Person member = new Person(name, age);
                family.AddMember(member);
            }

            for (int i = 0; i < family.People.Count; i++)
            {
                if (family.People[i].Age > 30)
                {
                    olderPeople.Add(family.People[i]);
                }
            }

            olderPeople = olderPeople.OrderBy(p => p.Name).ToList();
            
            foreach (var person in olderPeople)
            {
                Console.WriteLine($"{person.Name} - {person.Age}");
            }
        }
    }
}
