namespace CarRacing.Models.Maps
{
    using System;
    using CarRacing.Models.Maps.Contracts;
    using CarRacing.Models.Racers.Contracts;
    using CarRacing.Utilities.Messages;

    public class Map : IMap
    {
        public string StartRace(IRacer racerOne, IRacer racerTwo)
        {
            if (!racerOne.IsAvailable() && !racerTwo.IsAvailable())
            {
                return string.Format(OutputMessages.RaceCannotBeCompleted);
            }

            if (!racerOne.IsAvailable())
            {
                return string.Format(OutputMessages.OneRacerIsNotAvailable, racerTwo.Username, racerOne.Username);
            }

            if (!racerTwo.IsAvailable())
            {
                return string.Format(OutputMessages.OneRacerIsNotAvailable, racerOne.Username, racerTwo.Username);
            }

            double racerOneBehaviourMultiplier = racerOne.RacingBehavior == "strict" ? 1.2 : 1.1;
            double racerTwoBehaviourMultiplier = racerOne.RacingBehavior == "strict" ? 1.2 : 1.1;


            double racerOneWinningChances = 
                racerOne.Car.HorsePower * racerOne.DrivingExperience * racerOneBehaviourMultiplier;

            double racerTwoWinningChances =
                racerTwo.Car.HorsePower * racerTwo.DrivingExperience * racerTwoBehaviourMultiplier;

            string winnerUsername =
                racerOneWinningChances > racerTwoWinningChances ? racerOne.Username : racerTwo.Username;

            racerOne.Race();
            racerTwo.Race();

            return string.Format(OutputMessages.RacerWinsRace, racerOne.Username, racerTwo.Username, winnerUsername);
        }
    }
}
