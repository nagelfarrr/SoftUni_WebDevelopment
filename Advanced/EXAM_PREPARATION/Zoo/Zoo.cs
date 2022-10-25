using System.Collections.Generic;
using System.Linq;

namespace Zoo
{
    public class Zoo
    {
        private List<Animal> animals;

        public Zoo(string name, int capacity)
        {
            this.animals = new List<Animal>();
            this.Name = name;
            this.Capacity = capacity;
        }

        public string Name { get; set; }
        public int Capacity { get; set; }
        public List<Animal> Animals {
            get { return this.animals; }
        }


        public string AddAnimal(Animal animal)
        {
            if (string.IsNullOrEmpty(animal.Species))
                return "Invalid animal species.";
            else if (animal.Diet != "herbivore" && animal.Diet != "carnivore")
                return "Invalid animal diet.";
            else if (this.Capacity <= this.animals.Count)
                return "The zoo is full.";

            this.animals.Add(animal);
            return $"Successfully added {animal.Species} to the zoo.";
        }

        public int RemoveAnimals(string species)
        {
            int removedAnimals = this.animals.RemoveAll(a => a.Species == species);
            return removedAnimals;
        }

        public List<Animal> GetAnimalsByDiet(string diet)
        {
            return this.animals.FindAll(a => a.Diet == diet);
        }

        public Animal GetAnimalByWeight(double weight)
        {
            return this.animals.First(a => a.Weight == weight);
        }

        public string GetAnimalCountByLength(double minimumLength, double maximumLength)
        {
            int count = 0;

            foreach (var animal in this.animals)
            {
                if (animal.Length >= minimumLength && animal.Length <= maximumLength)
                {
                    count++;
                }
            }

            return $"There are {count} animals with a length between {minimumLength} and {maximumLength} meters.";
        }
    }
}
