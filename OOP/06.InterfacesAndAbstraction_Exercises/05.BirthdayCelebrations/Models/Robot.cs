namespace BirthdayCelebrations.Models
{
    using System;
    using BirthdayCelebrations.Models.Contracts;

    public class Robot : IRobot
    {
        private string model;
        private string id;

        public Robot(string model, string id)
        {
            this.Model = model;
            this.Id = id;
        }


        public string Model
        {
            get=>this.model;

            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Invalid Model");
                }

                this.model = value;
            }
        }

        public string Id
        {
            get => this.id;

            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Invalid ID");
                }

                this.id = value;
            }
        }
    }
}
