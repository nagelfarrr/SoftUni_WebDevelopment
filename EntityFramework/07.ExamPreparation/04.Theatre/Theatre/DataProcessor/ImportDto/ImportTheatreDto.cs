using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace Theatre.DataProcessor.ImportDto
{
    public class ImportTheatreDto
    {
        [JsonProperty("Name")]
        [MinLength(4)]
        [MaxLength(30)]
        public string Name { get; set; }

        [JsonProperty("NumberOfHalls")]
        [Range(1, 10)]
        public sbyte NumberOfHalls { get; set; }

        [JsonProperty("Director")]
        [MinLength(4)]
        [MaxLength(30)]
        public string Director { get; set; }

        public ImportTicketDto[] Tickets { get; set; }
    }

    public class ImportTicketDto
    {
        [JsonProperty("Price")]
        [Range(1.00, 100.00)]
        public decimal Price { get; set; }

        [JsonProperty("RowNumber")]
        [Range(1, 10)]
        public sbyte RowNumber { get; set; }

        [JsonProperty("PlayId")]
        public int PlayId { get; set; }
    }
}
