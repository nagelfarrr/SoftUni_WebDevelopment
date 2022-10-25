using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace DefiningClasses
{
    public class Family
    {
        private List<Person> people;

        public Family()
        {
            this.People = new List<Person>();
        }
        public List<Person> People
        {
            get { return this.people; }
            set { this.people = value; }
        }

        public void AddMember(Person member)
        {
            this.people.Add(member);
        }

        public string GetOldestMember(List<Person> people)
        {
            people = this.people.OrderByDescending(p => p.Age).ToList();

            return $"{people.First().Name} {people.First().Age}";
        }
    }
}
