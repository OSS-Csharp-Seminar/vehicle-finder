using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.UseSerialColumns();

            modelBuilder.Entity<Vehicle>()
                .HasOne(v => v.VehicleEngine)
                .WithMany()
                .HasForeignKey(v => v.VehicleEngineId);

            modelBuilder.Entity<Vehicle>()
                .HasOne(v => v.VehicleBody)
                .WithMany()
                .HasForeignKey(v => v.VehicleBodyId);

            modelBuilder.Entity<Vehicle>()
                .HasOne(v => v.VehicleMaintenance)
                .WithMany()
                .HasForeignKey(v => v.VehicleMaintenanceId);

            modelBuilder.Entity<Listing>()
                .HasOne(l => l.Vehicle)
                .WithOne()
                .HasForeignKey<Listing>(l => l.VehicleId);
        }

        public DbSet<Body> Bodies { get; set; }
        public DbSet<Engine> Engines { get; set; }
        public DbSet<Listing> Listings { get; set; }
        public DbSet<Maintenance> Maintenances { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Vehicle> Vehicles { get; set; }
    }
}
