namespace _04.BorderControl.Models
{
    using System;
    using Contracts;

    internal class Citizen : ICitizen
    {
        private string name;
        private int age;
        private string id;

        public Citizen(string name, int age, string id)
        {
            this.Name = name;
            this.Age = age;
            this.Id = id;
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
    }
}
