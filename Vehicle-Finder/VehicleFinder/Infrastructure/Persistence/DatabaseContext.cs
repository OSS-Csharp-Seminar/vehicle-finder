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
                .HasOne(v => v.vehicle_body)
                .WithOne()
                .HasForeignKey<Vehicle>("body_id");

            modelBuilder.Entity<Vehicle>()
                .HasOne(v => v.vehicle_maintenance)
                .WithOne()
                .HasForeignKey<Vehicle>("maintenance_id");

            modelBuilder.Entity<Vehicle>()
                .HasOne(v => v.vehicle_engine)
                .WithOne()
                .HasForeignKey<Vehicle>("engine_id"); 
        }

        public DbSet<Body> Bodies { get; set; }
        public DbSet<Engine> Engines { get; set; }
        public DbSet<Listing> Listings { get; set; }
        public DbSet<Maintenance> Maintenances { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Vehicle> Vehicles { get; set; }
    }
}
