using System;
using System.Collections.Generic;
using System.Text;

namespace PersonsInfo
{
    public class Person
    {
        private string firstName;
        private string lastName;
        private int age;
        private decimal salary;


        public Person(string firstName, string lastName, int age, decimal salary)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Age = age;
            this.Salary = salary;
        }


        public string FirstName
        {
            get
            {
                return this.firstName;
            }
            private set
            {
                if (value.Length < 3)
                {
                    throw new ArgumentException("First name cannot contain fewer than 3 symbols!");
                }
                this.firstName = value;
            }
        }
        public string LastName
        {
            get { return this.lastName; }
            private set
            {
                if (value.Length < 3)
                {
                    throw new ArgumentException("Last name cannot contain fewer than 3 symbols!");
                }

                this.lastName = value;
            }
        }

        public int Age
        {
            get
            {
                return this.age;
            }
            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Age cannot be zero or a negative integer!");
                }

                this.age = value;
            }
        }

        public decimal Salary
        {
            get
            {
                return this.salary;
            }
            private set
            {
                if (value < 460M)
                {
                    throw new ArgumentException("Salary cannot be less than 650 leva");
                }
                this.salary = value;
            }
        }


        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"{this.FirstName} {this.LastName} receives {this.Salary:F2} leva.");

            return sb.ToString().Trim();
        }

        public void IncreaseSalary(decimal percentage)
        {
            if (this.Age > 30)
                this.Salary += Salary * percentage / 100;

            else
                this.Salary += Salary * percentage / 200;


        }
    }
}
