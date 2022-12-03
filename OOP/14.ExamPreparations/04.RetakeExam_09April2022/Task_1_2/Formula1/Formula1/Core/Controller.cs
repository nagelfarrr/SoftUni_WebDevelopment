namespace Formula1.Core
{
    using System;
    using System.Linq;
    using System.Text;
    using Formula1.Core.Contracts;
    using Formula1.Models;
    using Formula1.Models.Contracts;
    using Formula1.Repositories;
    using Formula1.Repositories.Contracts;
    using Formula1.Utilities;

    public class Controller : IController
    {
        private PilotRepository pilotRepository;
        private RaceRepository raceRepository;
        private FormulaOneCarRepository carRepository;

        public Controller()
        {
            this.pilotRepository = new PilotRepository();
            this.raceRepository = new RaceRepository();
            this.carRepository = new FormulaOneCarRepository();
        }

        public string CreatePilot(string fullName)
        {
            if (pilotRepository.Models.Any(p => p.FullName == fullName))
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.PilotExistErrorMessage, fullName));
            }

            IPilot pilot = new Pilot(fullName);
            pilotRepository.Add(pilot);

            return string.Format(OutputMessages.SuccessfullyCreatePilot, fullName);
        }

        public string CreateCar(string type, string model, int horsepower, double engineDisplacement)
        {
            if (carRepository.Models.Any(c => c.Model == model))
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.CarExistErrorMessage, model));
            }

            if (type != "Ferrari" && type != "Williams")
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.InvalidTypeCar, type));
            }

            IFormulaOneCar car = null;

            if (type == "Ferrari")
            {
                car = new Ferrari(model, horsepower, engineDisplacement);
            }
            else if (type == "Williams")
            {
                car = new Williams(model, horsepower, engineDisplacement);
            }

            carRepository.Add(car);

            return string.Format(OutputMessages.SuccessfullyCreateCar, type, model);
        }

        public string CreateRace(string raceName, int numberOfLaps)
        {
            if (raceRepository.Models.Any(r => r.RaceName == raceName))
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.RaceExistErrorMessage, raceName));
            }

            IRace race = new Race(raceName, numberOfLaps);

            raceRepository.Add(race);

            return string.Format(OutputMessages.SuccessfullyCreateRace, raceName);
        }

        public string AddCarToPilot(string pilotName, string carModel)
        {
            if (!pilotRepository.Models.Any(p => p.FullName == pilotName) || pilotRepository.Models.First(p => p.FullName == pilotName).CanRace)
            {
                throw new InvalidOperationException(
                    string.Format(ExceptionMessages.PilotDoesNotExistOrHasCarErrorMessage, pilotName));
            }

            if (!carRepository.Models.Any(c => c.Model == carModel))
            {
                throw new NullReferenceException(string.Format(ExceptionMessages.CarDoesNotExistErrorMessage,
                    carModel));
            }

            var carToAdd = carRepository.Models.First(c => c.Model == carModel);
            var pilot = pilotRepository.Models.First(p => p.FullName == pilotName);

            pilot.AddCar(carToAdd);

            carRepository.Remove(carToAdd);

            return string.Format(OutputMessages.SuccessfullyPilotToCar, pilotName, pilot.Car.GetType().Name, carModel);
        }

        public string AddPilotToRace(string raceName, string pilotFullName)
        {
            if (!raceRepository.Models.Any(r => r.RaceName == raceName))
            {
                throw new NullReferenceException(
                    string.Format(ExceptionMessages.RaceDoesNotExistErrorMessage, raceName));
            }
            var race = raceRepository.Models.First(r=>r.RaceName == raceName);

            if (!pilotRepository.Models.Any(p => p.FullName == pilotFullName))
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.PilotDoesNotExistErrorMessage,
                    pilotFullName));
            }

            var pilot = pilotRepository.Models.First(p=>p.FullName == pilotFullName);

            if ((!pilot.CanRace) || race.Pilots.Any(p => p.FullName == pilotFullName))
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.PilotDoesNotExistErrorMessage,
                    pilotFullName));
            }
            race.AddPilot(pilot);

            return string.Format(OutputMessages.SuccessfullyAddPilotToRace, pilotFullName, raceName);
        }

        public string StartRace(string raceName)
        {
            if (!raceRepository.Models.Any(x => x.RaceName == raceName))
                throw new NullReferenceException(String.Format(Utilities.ExceptionMessages.RaceDoesNotExistErrorMessage, raceName));
            IRace race = raceRepository.FindByName(raceName);
            if (race.Pilots.Count < 3)
                throw new InvalidOperationException(String.Format(Utilities.ExceptionMessages.InvalidRaceParticipants, raceName));
            if (race.TookPlace)
                throw new InvalidOperationException(String.Format(Utilities.ExceptionMessages.RaceTookPlaceErrorMessage, raceName));

            race.TookPlace = true;
            int laps = race.NumberOfLaps;
            var orderedPilots = race.Pilots.OrderByDescending(x => x.Car.RaceScoreCalculator(laps));
            IPilot first = orderedPilots.FirstOrDefault();
            IPilot second = orderedPilots.Skip(1).FirstOrDefault();
            IPilot third = orderedPilots.Skip(2).FirstOrDefault();
            first.WinRace();


            StringBuilder result = new StringBuilder();

            result.AppendLine(string.Format(OutputMessages.PilotFirstPlace,first.FullName,raceName));
            result.AppendLine(string.Format(OutputMessages.PilotSecondPlace,second.FullName,raceName));
            result.AppendLine(string.Format(OutputMessages.PilotThirdPlace,third.FullName,raceName));

            return result.ToString().Trim();
        }

        public string RaceReport()
        {
            StringBuilder output = new StringBuilder();
            foreach (var race in raceRepository.Models.Where(r => r.TookPlace))
            {
                output.AppendLine(race.RaceInfo());
            }

            return output.ToString().Trim();
        }

        public string PilotReport()
        {
            StringBuilder output = new StringBuilder();

            foreach (var pilot in pilotRepository.Models.OrderByDescending(p => p.NumberOfWins))
            {
                output.AppendLine(pilot.ToString());
            }

            return output.ToString().Trim();
        }
    }
}
