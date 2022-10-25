using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PokemonTrainer
{
    public class Trainer
    {
        public Trainer(string name)
        {
            this.Name = name;
            this.Pokemons = new List<Pokemon>();
        }

        public string Name { get; set; }
        public int NumberOfBadges { get; set; }
        public List<Pokemon> Pokemons { get; set; }

        public void CheckPokemon(string element)
        {
            if (this.Pokemons.Any(p => p.Element == element))
            {
                NumberOfBadges++;
            }
            else
            {
                for (int i = 0; i < this.Pokemons.Count; i++)
                {
                    Pokemon currentPokemon = this.Pokemons[i];

                    currentPokemon.Health -= 10;

                    if (currentPokemon.Health <= 0)
                    {
                        this.Pokemons.Remove(currentPokemon);
                    }
                }
            }
        }
    }
}
