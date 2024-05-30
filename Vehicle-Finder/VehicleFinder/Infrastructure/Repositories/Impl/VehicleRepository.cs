using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using VehicleFinder.Infrastructure.Repositories.Interfaces;
using Domain.Entities;
using Infrastructure.Persistence;

namespace VehicleFinder.Infrastructure.Repositories
{
    public class VehicleRepository : IVehicleRepository
    {
        private readonly DatabaseContext _context;

        public VehicleRepository(DatabaseContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Vehicle>> GetAllVehiclesAsync()
        {
            return await _context.Vehicles
                .Include(v => v.VehicleEngine)
                .Include(v => v.VehicleBody)
                .Include(v => v.VehicleMaintenance)
                .ToListAsync();
        }

        public async Task<Vehicle> GetVehicleByIdAsync(Guid id)
        {
            var vehicle = await _context.Vehicles
                .Include(v => v.VehicleEngine)
                .Include(v => v.VehicleBody)
                .Include(v => v.VehicleMaintenance)
                .FirstOrDefaultAsync(v => v.Id == id);

            if (vehicle == null)
                throw new KeyNotFoundException("Vehicle not found!");

            return vehicle;
        }

        public async Task<Vehicle> AddVehicleAsync(Vehicle vehicle)
        {
            _context.Vehicles.Add(vehicle);
            await _context.SaveChangesAsync();
            return vehicle;
        }

        public async Task<Vehicle> UpdateVehicleAsync(Vehicle vehicle)
        {
            _context.Entry(vehicle).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return vehicle;
        }

        public async Task<bool> DeleteVehicleAsync(Vehicle vehicle)
        {
            _context.Vehicles.Remove(vehicle);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
