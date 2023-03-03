namespace MusicHub.Data
{
    using Microsoft.EntityFrameworkCore;
    using MusicHub.Data.Models;

    public class MusicHubDbContext : DbContext
    {
        public MusicHubDbContext()
        {
        }

        public MusicHubDbContext(DbContextOptions options)
            : base(options)
        {
        }

        public DbSet<Song> Songs { get; set; } = null!;

        public DbSet<Album> Albums { get; set; } = null!;

        public DbSet<Performer> Performers { get; set; } = null!;

        public DbSet<Producer> Producers { get; set; } = null!;

        public DbSet<Writer> Writers { get; set; } = null!;

        public DbSet<SongPerformer> SongsPerformers { get; set; } = null!;


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder
                    .UseSqlServer(Configuration.ConnectionString);
            }
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Song>(entity =>
            {
                entity.Property(s => s.Price).HasColumnType("money");
            });

            builder.Entity<SongPerformer>(entity =>
            {
                entity.HasKey(sp => new
                {
                    sp.SongId,
                    sp.PerformerId
                });
            });
        }
    }
}
