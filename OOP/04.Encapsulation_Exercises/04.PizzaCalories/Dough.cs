using System;
using System.Collections.Generic;
using System.Text;

namespace _04.PizzaCalories
{
    public class Dough
    {
        //dough modifiers
        private const double FlourWhite = 1.5;
        private const double FlourWholegrain = 1.0;
        private const double BakeCrispy = 0.9;
        private const double BakeChewy = 1.1;
        private const double BakeHomemade = 1.0;


        private string flourType;
        private string bakingTechnique;
        private double weight;

        public Dough(string flourType, string bakingTechnique, double weight)
        {
            this.FlourType = flourType;
            this.BakingTechnique = bakingTechnique;
            this.Weight = weight;
        }


        public string FlourType
        {
            set
            {
                if (value.ToLower() != "white" && value.ToLower() != "wholegrain")
                    throw new ArgumentException("Invalid type of dough.");

                this.flourType = value;
            }
        }

        public string BakingTechnique
        {
            set
            {
                if (value.ToLower() != "crispy" && value.ToLower() != "chewy" && value.ToLower() != "homemade")
                    throw new ArgumentException("Invalid type of dough.");

                this.bakingTechnique = value;
            }
        }

        public double Weight
        {
            set
            {
                if (value < 1 || value > 200)
                    throw new ArgumentException("Dough weight should be in the range[1..200].");
                this.weight = value;
            }
        }

        public double CaloriesPerGram
        {
            get
            {
                double caloriesPerGram = 2;

                if (this.flourType.ToLower() == "white")
                    caloriesPerGram *= FlourWhite;
                else if (this.flourType.ToLower() == "wholegrain")
                    caloriesPerGram *= FlourWholegrain;

                if (this.bakingTechnique.ToLower() == "crispy")
                    caloriesPerGram *= BakeCrispy;
                else if (this.bakingTechnique.ToLower() == "chewy") 
                    caloriesPerGram *= BakeChewy;
                else if (this.bakingTechnique.ToLower() == "homemade")
                    caloriesPerGram *= BakeHomemade;

                return caloriesPerGram;
            }
        }


        public double GetCalories()
        {
            return weight * this.CaloriesPerGram;
        }

    }
}
