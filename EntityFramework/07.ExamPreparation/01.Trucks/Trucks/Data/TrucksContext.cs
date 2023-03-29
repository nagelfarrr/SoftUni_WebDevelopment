namespace Trucks.Data
{
    using Microsoft.EntityFrameworkCore;
    using Trucks.Data.Models;

    public class TrucksContext : DbContext
    {
        public TrucksContext()
        {
        }

        public TrucksContext(DbContextOptions options)
            : base(options)
        {
        }

        public DbSet<Truck> Trucks { get; set; }

        public DbSet<Client> Clients { get; set; }

        public DbSet<Despatcher> Despatchers { get; set; }

        public DbSet<ClientTruck> ClientsTrucks { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder
                    .UseSqlServer(Configuration.ConnectionString);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ClientTruck>(e =>
            {
                e.HasKey(ct => new
                {
                    ct.ClientId,
                    ct.TruckId
                });
            });
        }
    }
}
