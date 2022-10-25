using System;
using System.Collections.Generic;
using System.Linq;

namespace PokemonTrainer
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            Dictionary<string, Trainer> trainers = new Dictionary<string, Trainer>();

            while (true)
            {
                string input = Console.ReadLine();
                if (input == "Tournament")
                    break;

                string[] tokens = input.Split(" ", StringSplitOptions.RemoveEmptyEntries);

                string trainerName = tokens[0];
                string pokemonName = tokens[1];
                string pokemonElement = tokens[2];
                int pokemonHealth = int.Parse(tokens[3]);

                Pokemon pokemon = new Pokemon(pokemonName, pokemonElement, pokemonHealth);

                Trainer trainer = new Trainer(trainerName);

                if (!trainers.ContainsKey(trainerName))
                    trainers.Add(trainerName, trainer);

                trainers[trainerName].Pokemons.Add(pokemon);

            }

            while (true)
            {
                string input = Console.ReadLine();
                if (input == "End")
                    break;

                foreach (var trainer in trainers)
                {
                    trainer.Value.CheckPokemon(input);
                }

            }

            foreach (var trainer in trainers.OrderByDescending(t=>t.Value.NumberOfBadges))
            {
                Console.WriteLine($"{trainer.Value.Name} {trainer.Value.NumberOfBadges} {trainer.Value.Pokemons.Count}");
            }
        }
    }
}
