namespace NavalVessels.Core
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using NavalVessels.Core.Contracts;
    using NavalVessels.Models;
    using NavalVessels.Models.Contracts;
    using NavalVessels.Repositories;
    using NavalVessels.Repositories.Contracts;
    using NavalVessels.Utilities.Messages;

    public class Controller : IController
    {
        private IRepository<IVessel> vessels;
        private List<ICaptain> captains;

        public Controller()
        {
            this.vessels = new VesselRepository();
            this.captains = new List<ICaptain>();
        }

        public string HireCaptain(string fullName)
        {
            if (captains.Any(c => c.FullName == fullName))
            {
                return string.Format(OutputMessages.CaptainIsAlreadyHired,fullName);
            }

            ICaptain captain = new Captain(fullName);
            captains.Add(captain);

            return string.Format(OutputMessages.SuccessfullyAddedCaptain, fullName);
        }

        public string ProduceVessel(string name, string vesselType, double mainWeaponCaliber, double speed)
        {
            if (vessels.FindByName(name) !=null)
            {
                return string.Format(OutputMessages.VesselIsAlreadyManufactured, vesselType, name);
            }

            if (vesselType != "Submarine" && vesselType != "Battleship")
            {
                return OutputMessages.InvalidVesselType;
            }

            IVessel vessel = null;

            if (vesselType == "Submarine")
            {
                vessel = new Submarine(name, mainWeaponCaliber, speed);
            }
            else if (vesselType == "Battleship")
            {
                vessel = new Battleship(name, mainWeaponCaliber, speed);
            }

            vessels.Add(vessel);

            return string.Format(OutputMessages.SuccessfullyCreateVessel, vesselType, name, mainWeaponCaliber, speed);
        }

        public string AssignCaptain(string selectedCaptainName, string selectedVesselName)
        {
            if (!captains.Any(c => c.FullName == selectedCaptainName))
            {
                return string.Format(OutputMessages.CaptainNotFound, selectedCaptainName);
            }

            if (!vessels.Models.Any(v => v.Name == selectedVesselName))
            {
                return string.Format(OutputMessages.VesselNotFound, selectedVesselName);
            }

            var captain = captains.Find(c => c.FullName == selectedCaptainName);
            var vessel = vessels.FindByName(selectedVesselName); //not sure about this

            if (vessel.Captain != null)
            {
                return string.Format(OutputMessages.VesselOccupied, selectedVesselName);
            }

            captain.AddVessel(vessel);
            vessel.Captain = captain; // not sure about this

            return string.Format(OutputMessages.SuccessfullyAssignCaptain, selectedCaptainName,selectedVesselName);
        }

        public string CaptainReport(string captainFullName)
        {
            var captain = captains.Find(c => c.FullName == captainFullName);

            return captain.Report();
        }

        public string VesselReport(string vesselName)
        {
            var vessel = vessels.FindByName(vesselName); // might not work

            return vessel.ToString();
        }

        public string ToggleSpecialMode(string vesselName)
        {
            var vessel = vessels.FindByName(vesselName);

            if (vessel == null)
            {
                return string.Format(OutputMessages.VesselNotFound, vesselName);
            }

            if (vessel.GetType().Name == "Submarine")
            {
                (vessel as Submarine).ToggleSubmergeMode();
                return string.Format(OutputMessages.ToggleSubmarineSubmergeMode, vessel.Name);
            }
            else
            {
                (vessel as Battleship).ToggleSonarMode();
                return string.Format(OutputMessages.ToggleBattleshipSonarMode, vessel.Name);
            }
        }

        public string ServiceVessel(string vesselName)
        {
            var vessel = vessels.FindByName(vesselName);

            if (vessel == null)
            {
                return string.Format(OutputMessages.VesselNotFound, vesselName);
            }

            vessel.RepairVessel();

            return string.Format(OutputMessages.SuccessfullyRepairVessel, vesselName);
        }

        public string AttackVessels(string attackingVesselName, string defendingVesselName)
        {
            var attacker = vessels.FindByName(attackingVesselName);
            var defender = vessels.FindByName(defendingVesselName);

            if (attacker == null)
            {
                return string.Format(OutputMessages.VesselNotFound, attackingVesselName);
            }
            if (defender == null)
            {
                return string.Format(OutputMessages.VesselNotFound, defendingVesselName);
            }

            if (attacker.ArmorThickness == 0)
            {
                return string.Format(OutputMessages.AttackVesselArmorThicknessZero, attackingVesselName);
            }
            if (defender.ArmorThickness == 0)
            {
                return string.Format(OutputMessages.AttackVesselArmorThicknessZero, defendingVesselName);
            }

            attacker.Attack(defender);

            attacker.Captain.IncreaseCombatExperience();
            defender.Captain.IncreaseCombatExperience();

            return string.Format(OutputMessages.SuccessfullyAttackVessel, defendingVesselName, attackingVesselName,
                defender.ArmorThickness);
        }

    }
}
