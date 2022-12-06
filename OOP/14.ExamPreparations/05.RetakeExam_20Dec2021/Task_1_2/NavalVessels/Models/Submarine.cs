using System.Text;

namespace NavalVessels.Models
{
    using NavalVessels.Models.Contracts;

    public class Submarine : Vessel
    {
        private const double InitialArmorThickness = 200;


        public Submarine(string name, double mainWeaponCaliber, double speed) : base(name, mainWeaponCaliber, speed, InitialArmorThickness)
        {
            this.SubmergeMode = false;
        }


        public bool SubmergeMode { get; private set; }
        public override void RepairVessel()
        {
            if (this.ArmorThickness < InitialArmorThickness)
                this.ArmorThickness = InitialArmorThickness;
        }

        //might be private
        public void ToggleSubmergeMode()
        {
            this.SubmergeMode = !this.SubmergeMode;
            if (this.SubmergeMode)
            {
                this.MainWeaponCaliber += 40;
                this.Speed -= 4;
            }
            else
            {
                this.MainWeaponCaliber -= 40;
                this.Speed += 4;
            }
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine(base.ToString());
            string submergeMode;
            if (this.SubmergeMode)
            {
                submergeMode = "ON";
            }
            else
            {
                submergeMode = "OFF";
            }

            sb.AppendLine($" *Submerge mode: {submergeMode}");

            return sb.ToString().TrimEnd();
        }
    }
}
