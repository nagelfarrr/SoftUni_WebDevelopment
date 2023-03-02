namespace P02_FootballBetting.Data.Models;

using System.ComponentModel.DataAnnotations;

public class Country
{
    public Country()
    {
        this.Towns = new HashSet<Town>();
    }

    public int CountryId { get; set; }

    [Required]
    [MaxLength(25)]
    public string Name { get; set; } = null!;

    public ICollection<Town> Towns { get; set; }
}

