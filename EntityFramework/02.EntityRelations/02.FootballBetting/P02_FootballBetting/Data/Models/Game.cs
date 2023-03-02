namespace P02_FootballBetting.Data.Models;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class Game
{
    public Game()
    {
        this.PlayersStatistics = new HashSet<PlayerStatistic>();
        this.Bets = new HashSet<Bet>();
    }

    public int GameId { get; set; }

    [Required]
    [ForeignKey(nameof(HomeTeam))]
    public int HomeTeamId { get; set; }

    public Team? HomeTeam { get; set; }

    [Required]
    [ForeignKey(nameof(AwayTeam))]
    public int AwayTeamId { get; set; }

    public Team? AwayTeam { get; set; }

    [Required]
    public int HomeTeamGoals { get; set; }

    [Required]
    public int AwayTeamGoals { get; set; }

    [Required]
    public DateTime DateTime { get; set; }

    [Required]
    public decimal HomeTeamBetRate { get; set; }


    public decimal AwayTeamBetRate { get; set; }

    public decimal DrawBetRate { get; set; }

    [MaxLength(20)]
    public string Result { get; set; } = null!;

    public ICollection<PlayerStatistic> PlayersStatistics { get; set; }

    public ICollection<Bet> Bets { get; set; }


}
