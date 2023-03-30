using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace Artillery.DataProcessor.ImportDto
{
    public class ImportGunDto
    {
        [JsonProperty("ManufacturerId")]
        public int ManufacturerId { get; set; }

        [JsonProperty("GunWeight")]
        [Range(100, 1_350_000)]
        public int GunWeight { get; set; }

        [JsonProperty("BarrelLength")]
        [Range(2.00, 35.00)]
        public double BarrelLength { get; set; }

        [JsonProperty("NumberBuild")]
        public int? NumberBuild { get; set; }

        [JsonProperty("Range")]
        [Range(1, 100_000)]
        public int Range { get; set; }

        [JsonProperty("GunType")]
        public string GunType { get; set; } = null!;

        [JsonProperty("ShellId")]
        public int ShellId { get; set; }

        [JsonProperty("Countries")]
        public ImportCountryIdDto[] CountryIds { get; set; }
    }

    public class ImportCountryIdDto
    {
        [JsonProperty("Id")]
        public int Id { get; set; }
    }
}
