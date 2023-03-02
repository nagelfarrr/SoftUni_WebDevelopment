namespace P02_FootballBetting.Data.Models;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class Town
{
   public int TownId { get; set; }

    [Required]
    [MaxLength(50)]
    public string Name { get; set; } = null!;

    [Required]
    [ForeignKey(nameof(Country))]
    public int CountryId { get; set; }

    public Country Country { get; set; } = null!;

    
    public ICollection<Team>? Teams { get; set; }
}