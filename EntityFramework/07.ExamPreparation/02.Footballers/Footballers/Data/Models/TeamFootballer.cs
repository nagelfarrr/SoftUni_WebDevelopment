namespace Footballers.Data.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class TeamFootballer
    {
        [Required]
        [ForeignKey("Team")]
        public int TeamId { get; set; }

        public Team Team { get; set; }

        [Required]
        [ForeignKey("Footballer")]
        public int FootballerId { get; set; }

        public Footballer Footballer { get; set; }
    }
}
