namespace NavalVessels.Models
{
    using System.Text;
    using NavalVessels.Models.Contracts;

    public class Battleship : Vessel, IBattleship
    {
        private const double InitialArmorThickness = 300;
        public Battleship(string name, double mainWeaponCaliber, double speed) : base(name, mainWeaponCaliber, speed, InitialArmorThickness)
        {
            this.SonarMode = false;
        }

        public bool SonarMode { get; private set; }

        public override void RepairVessel()
        {
            if (this.ArmorThickness < InitialArmorThickness)
                this.ArmorThickness = InitialArmorThickness;
        }

        //might be private
        public void ToggleSonarMode()
        {
            this.SonarMode = !this.SonarMode;
            if (this.SonarMode)
            {
                
                this.MainWeaponCaliber += 40;
                this.Speed -= 5;
            }
            else
            {
                
                this.MainWeaponCaliber -= 40;
                this.Speed += 5;
            }
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine(base.ToString());
            string sonarMode;
            if (this.SonarMode)
            {
                sonarMode = "ON";
            }
            else
            {
                sonarMode = "OFF";
            }

            sb.AppendLine($"*Sonar mode: {sonarMode}");

            return sb.ToString().Trim();
        }
    }
}
