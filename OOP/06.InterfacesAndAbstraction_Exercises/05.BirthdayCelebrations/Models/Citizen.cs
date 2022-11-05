namespace BirthdayCelebrations.Models
{
    using System;
    using BirthdayCelebrations.Models.Contracts;

    internal class Citizen : ICitizen
    {
        private string name;
        private int age;
        private string id;
        private string birthdate;

        public Citizen(string name, int age, string id, string birthdate)
        {
            this.Name = name;
            this.Age = age;
            this.Id = id;
            this.Birthdate = birthdate;
        }

        public string Name
        {
            get => this.name;

            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Invalid name!");
                }

                this.name = value;
            }
        }

        public int Age
        {
            get => this.age;

            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Invalid age!");
                }

                this.age = value;
            }
        }

        public string Id
        {
            get => this.id;

            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Invalid ID");
                }

                this.id = value;
            }
        }

        public string Birthdate
        {
            get => this.birthdate;

            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    Console.WriteLine("Invalid birth date!");
                }

                this.birthdate = value;
            }
        }
    }
}
