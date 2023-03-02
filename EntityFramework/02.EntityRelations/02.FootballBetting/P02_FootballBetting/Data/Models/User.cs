namespace P02_FootballBetting.Data.Models;

using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

public class User
{
    public User()
    {
        this.Bets = new HashSet<Bet>();
    }

    public int UserId { get; set; }

    [MaxLength(15)]
    public string Username { get; set; } = null!;

    [MaxLength(20)]
    public string Password { get; set; } = null!;

    [MaxLength(20)]
    public string Email { get; set; } = null!;

    [MaxLength(25)]
    public string Name { get; set; } = null!;

    public decimal Balance { get; set; }

    public ICollection<Bet> Bets { get; set; }
}