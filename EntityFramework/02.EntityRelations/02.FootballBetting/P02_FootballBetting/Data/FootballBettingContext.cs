namespace P02_FootballBetting.Data;

using Microsoft.EntityFrameworkCore;
using P02_FootballBetting.Data.Models;

public class FootballBettingContext : DbContext
{
    public FootballBettingContext()
    {
        
    }

    public FootballBettingContext(DbContextOptions options)
        : base(options)
    {
        
    }

    public DbSet<Team> Teams { get; set; } = null!;

    public DbSet<Color> Colors { get; set; } = null!;

    public DbSet<Town> Towns { get; set; } = null!;

    public DbSet<Country> Countries { get; set; } = null!;

    public DbSet<Player> Players { get; set; } = null!;

    public DbSet<Position> Positions { get; set; } = null!;

    public DbSet<PlayerStatistic> PlayersStatistics { get; set; } = null!;

    public DbSet<Game> Games { get; set; } = null!;

    public DbSet<Bet> Bets { get; set; } = null!;

    public DbSet<User> Users { get; set; } = null!;

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            optionsBuilder
                .UseSqlServer(
                    "Server=.\\SQLEXPRESS;Database=BetSystemDemo;Trusted_Connection=True;Integrated Security = true;TrustServerCertificate = true;");
        }

        base.OnConfiguring(optionsBuilder);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<PlayerStatistic>(entity =>
        {
            entity.HasKey(ps => new
            {
                ps.PlayerId,
                ps.GameId
            });
        });

        modelBuilder.Entity<Team>(entity =>
        {
            entity
                .HasOne(t => t.PrimaryKitColor)
                .WithMany(c => c.PrimaryKitTeams)
                .HasForeignKey(t => t.PrimaryKitColorId)
                .OnDelete(DeleteBehavior.NoAction);

            entity
                .HasOne(t => t.SecondaryKitColor)
                .WithMany(c => c.SecondaryKitTeams)
                .HasForeignKey(t => t.SecondaryKitColorId)
                .OnDelete(DeleteBehavior.NoAction);
        });

        modelBuilder.Entity<Game>(entity =>
        {
            entity
                .HasOne(g => g.HomeTeam)
                .WithMany(t => t.HomeGames)
                .HasForeignKey(g => g.HomeTeamId)
                .OnDelete(DeleteBehavior.NoAction);

            entity
                .HasOne(g => g.AwayTeam)
                .WithMany(t => t.AwayGames)
                .HasForeignKey(g => g.AwayTeamId)
                .OnDelete(DeleteBehavior.NoAction);
        });
    }
}

