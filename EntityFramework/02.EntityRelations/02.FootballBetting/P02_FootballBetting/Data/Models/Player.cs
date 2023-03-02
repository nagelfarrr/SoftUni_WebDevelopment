namespace P02_FootballBetting.Data.Models;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class Player
{
    public Player()
    {
        this.PlayersStatistics = new HashSet<PlayerStatistic>();
    }

    public int PlayerId { get; set; }

    [Required]
    [MaxLength(80)]
    public string Name { get; set; } = null!;

    [Required]
    public int SquadNumber { get; set; }

    [Required]
    [ForeignKey(nameof(Team))]
    public int TeamId { get; set; }

    public Team Team { get; set; } = null!;

    [Required]
    [ForeignKey(nameof(Position))] 
    public int PositionId { get; set; }

    public Position Position { get; set; } = null!;

    [Required]
    public bool IsInjured { get; set; }

    public ICollection<PlayerStatistic> PlayersStatistics { get; set; }
}

