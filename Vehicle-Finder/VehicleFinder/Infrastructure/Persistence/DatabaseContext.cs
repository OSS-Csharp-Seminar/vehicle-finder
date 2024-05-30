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
                .HasOne(v => v.VehicleBody)
                .WithOne()
                .HasForeignKey<Vehicle>("BodyId");

            modelBuilder.Entity<Vehicle>()
                .HasOne(v => v.VehicleMaintenance)
                .WithOne()
                .HasForeignKey<Vehicle>("MaintenanceId");

            modelBuilder.Entity<Vehicle>()
                .HasOne(v => v.VehicleEngine)
                .WithOne()
                .HasForeignKey<Vehicle>("EngineId"); 
        }

        public DbSet<Body> Bodies { get; set; }
        public DbSet<Engine> Engines { get; set; }
        public DbSet<Listing> Listings { get; set; }
        public DbSet<Maintenance> Maintenances { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Vehicle> Vehicles { get; set; }
    }
}
