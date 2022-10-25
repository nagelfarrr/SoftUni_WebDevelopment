namespace Zoo
{
    public class Animal
    {
        private string species;
        private string diet;
        private double weight;
        private double length;

        public Animal(string species, string diet, double weight,double length)
        {
            this.Species = species;
            this.Diet = diet;
            this.Weight = weight;
            this.Length = length;
        }

        public string Species
        {
            get { return this.species;}
            set { this.species = value; }
        }

        public string Diet
        {
            get { return this.diet; }
            set { this.diet = value; }
        }

        public double Weight
        {
            get { return this.weight; }
            set { this.weight = value; }
        }

        public double Length
        {
            get { return this.length; }
            set { this.length = value; }
        }


        public override string ToString()
        {
            return $"The {this.Species} is a {this.Diet} and weighs {this.Weight} kg.";
        }
    }
}
