using Artillery.Data.Models.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Artillery.Data.Models
{
    public class Gun
    {
        public Gun()
        {
            this.CountriesGuns = new HashSet<CountryGun>();
        }

        [Key]
        public int Id { get; set; }

        [ForeignKey(nameof(Manufacturer))]
        public int ManufacturerId { get; set; }
        public Manufacturer Manufacturer { get; set; } = null!;

        [Required]
        [MaxLength(1350000)]
        public int GunWeight { get; set; }

        [Required]
        [MaxLength(35)]
        public double BarrelLength { get; set; }

        public int? NumberBuild { get; set; }

        [Required]
        [MaxLength(100000)]
        public int Range { get; set; }

        [Required]
        public GunType GunType { get; set; }

        [ForeignKey(nameof(Shell))]
        public int ShellId { get; set; }
        public Shell Shell { get; set; } = null!;

        public ICollection<CountryGun> CountriesGuns { get; set; }
    }
}
