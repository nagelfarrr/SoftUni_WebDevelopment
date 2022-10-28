using System.Text;
using System;

namespace PersonsInfo
{
    public class Person
    {
        public Person(string firstName, string lastName, int age,decimal salary)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Age = age;
            this.Salary = salary;
        }



        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public int Age { get; private set; }
        public decimal Salary { get; private set; }


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