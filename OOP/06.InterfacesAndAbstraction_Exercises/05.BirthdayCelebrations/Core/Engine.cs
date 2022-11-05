namespace BirthdayCelebrations.Core
{
    using System;
    using System.Collections.Generic;
   
    using BirthdayCelebrations.Core.Contracts;
    using BirthdayCelebrations.Models;
    using BirthdayCelebrations.Models.Contracts;

    public class Engine :IEngine
    {
        public void Run()
        {
            List<IBirthable> birthables = new List<IBirthable>();

            while (true)
            {
                string[] input = Console.ReadLine().Split();
                if (input[0] == "End") break;

                try
                {
                    if (input[0] == "Robot")
                    {
                        string model = input[1];
                        string id = input[2];

                        IPopulation robot = new Robot(model, id);

                        
                    }

                    else if (input[0] == "Citizen")
                    {
                        string name = input[1];
                        int age = int.Parse(input[2]);
                        string id = input[3];
                        string birthdate = input[4];

                        IBirthable citizen = new Citizen(name, age, id,birthdate);

                        birthables.Add(citizen);
                    }
                    else if (input[0] == "Pet")
                    {
                        string name = input[1];
                        string birthdate = input[2];

                        IBirthable pet = new Pet(name, birthdate);

                        birthables.Add(pet);

                    }
                }

                catch (ArgumentException ae)
                {
                    Console.WriteLine(ae.Message);
                }
            }

            List<IBirthable> celebrating = new List<IBirthable>();

            string celebReq = Console.ReadLine();


            foreach (var unit in birthables)
            {
                if (unit.Birthdate.EndsWith(celebReq))
                {
                    celebrating.Add(unit);
                }
            }


            foreach (var unit in celebrating)
            {
                Console.WriteLine($"{unit.Birthdate}");
            }
        }
    }
}
