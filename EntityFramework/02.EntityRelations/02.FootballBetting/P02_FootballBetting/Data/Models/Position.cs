namespace P02_FootballBetting.Data.Models;

using System.ComponentModel.DataAnnotations;

public class Position
{
    public Position()
    {
        this.Players = new HashSet<Player>();
    }

    public int PositionId { get; set; }

    [Required]
    [MaxLength(40)]
    public string Name { get; set; } = null!;

    public ICollection<Player> Players { get; set; }
}