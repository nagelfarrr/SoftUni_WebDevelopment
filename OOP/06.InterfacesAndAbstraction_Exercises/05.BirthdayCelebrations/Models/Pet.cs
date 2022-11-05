namespace BirthdayCelebrations.Models
{
    using System;
    using BirthdayCelebrations.Models.Contracts;

    public class Pet :IAnimal
    {
        private string name;
        private string birthdate;

        public Pet(string name, string birthdate)
        {
            this.Name = name;
            this.Birthdate = birthdate;
        }

        public string Name
        {
            get=>this.name;

            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Invalid name!");
                }

                this.name = value;
            }
        }

        public string Birthdate
        {
            get=>this.birthdate;

            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Invalid birth date!");
                }

                this.birthdate = value;
            }
        }
    }
}
