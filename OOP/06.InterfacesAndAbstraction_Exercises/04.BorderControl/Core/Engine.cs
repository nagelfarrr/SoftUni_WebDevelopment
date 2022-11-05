namespace _04.BorderControl.Core
{
    using System;
    using System.Collections.Generic;

    using Contracts;
    using _04.BorderControl.Models;
    using _04.BorderControl.Models.Contracts;

    public class Engine :IEngine
    {
        public void Run()
        {
            List<IPopulation> population = new List<IPopulation>();

            while (true)
            {
                string[] input = Console.ReadLine().Split();
                if (input[0] == "End") break;

                try
                {
                    if (input.Length == 2)
                    {
                        string model = input[0];
                        string id = input[1];

                        IPopulation robot = new Robot(model, id);

                        population.Add(robot);
                    }

                    else if (input.Length == 3)
                    {
                        string name = input[0];
                        int age = int.Parse(input[1]);
                        string id = input[2];

                        IPopulation citizen = new Citizen(name, age, id);

                        population.Add(citizen);
                    }
                }

                catch (ArgumentException ae)
                {
                    Console.WriteLine(ae.Message);
                }
            }

            List<IPopulation> detained = new List<IPopulation>();

            string detainReqs = Console.ReadLine();


            foreach (var unit in population)
            {
                if (unit.Id.EndsWith(detainReqs))
                {
                    detained.Add(unit);
                }
            }


            foreach (var unit in detained)
            {
                Console.WriteLine($"{unit.Id}");
            }
        }
    }
}
