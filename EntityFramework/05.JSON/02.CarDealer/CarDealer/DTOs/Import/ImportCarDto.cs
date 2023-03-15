using CarDealer.Models;

namespace CarDealer.DTOs.Import
{
    public class ImportCarDto
    {
        public string Make { get; set; } = null!;

        public string Model { get; set; } = null!;

        public long TravelledDistance { get; set; }

        public ICollection<int> PartsId { get; set; } = new HashSet<int>();
    }
}
