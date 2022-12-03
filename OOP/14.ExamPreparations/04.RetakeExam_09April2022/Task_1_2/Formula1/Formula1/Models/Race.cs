namespace Formula1.Models
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using Formula1.Models.Contracts;
    using Formula1.Utilities;

    public class Race : IRace
    {
        private string raceName;
        private int numberOfLaps;
        private ICollection<IPilot> pilots;
        public Race(string raceName,int numberOfLaps)
        {
            this.TookPlace = false;
            this.pilots = new List<IPilot>();

            this.RaceName = raceName;
            this.NumberOfLaps = numberOfLaps;
        }
        public string RaceName
        {
            get => this.raceName;
            private set
            {
                if (string.IsNullOrWhiteSpace(value) || value.Length < 5)
                {
                    throw new ArgumentException(string.Format(ExceptionMessages.InvalidRaceName, value));
                }

                this.raceName = value;
            }
        }
        public int NumberOfLaps
        {
            get => this.numberOfLaps;
            private set
            {
                if (value < 1)
                {
                    throw new ArgumentException(string.Format(ExceptionMessages.InvalidLapNumbers, value));
                }

                this.numberOfLaps = value;
            }
        }
        public bool TookPlace { get;  set; }
        public ICollection<IPilot> Pilots => this.pilots;
        
        public void AddPilot(IPilot pilot)
        {
            this.Pilots.Add(pilot);
        }

        public string RaceInfo()
        {
            StringBuilder sb = new StringBuilder();

            string tookPlaceStr = this.TookPlace ? "Yes" : "No";

            sb.AppendLine($"The {this.RaceName} race has:");
            sb.AppendLine($"Participants: {this.Pilots.Count}");
            sb.AppendLine($"Number of laps: {this.NumberOfLaps}");
            sb.AppendLine($"Took place: {tookPlaceStr}");
            
            return sb.ToString().Trim();
        }
    }
}
