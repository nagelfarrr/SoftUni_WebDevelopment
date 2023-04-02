namespace Boardgames.DataProcessor.ImportDto
{
    using System.ComponentModel.DataAnnotations;
    using Newtonsoft.Json;

    public class ImportSellerDto
    {
        [JsonProperty("Name")]
        [MinLength(5)]
        [MaxLength(20)]
        public string Name { get; set; }

        
        [JsonProperty("Address")]
        [MinLength(2)]
        [MaxLength(30)]
        public string Address { get; set; }

        [JsonProperty("Country")]
        public string Country  { get; set; }

        [JsonProperty("Website")]
        [RegularExpression(@"^www\.[a-zA-Z0-9\-]+\.com$")]
        public string Website { get; set; }

        [JsonProperty("Boardgames")]
        public int[] BoardgamesIds { get; set; }
    }
}
