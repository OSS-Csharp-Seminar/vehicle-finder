using Microsoft.EntityFrameworkCore;
using Domain.Entities;
using Infrastructure.Persistence;

namespace Infrastructure.Repositories.Impl
{
    public class MaintenanceRepository : IMaintenanceRepository
    {
        private readonly DatabaseContext _context;

        public MaintenanceRepository(DatabaseContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Maintenance>> GetAllMaintenancesAsync()
        {
            return await _context.Maintenances.ToListAsync();
        }

        public async Task<Maintenance> GetMaintenanceByIdAsync(Guid id)
        {
            return await _context.Maintenances.FindAsync(id);
        }

        public async Task<Maintenance> AddMaintenanceAsync(Maintenance maintenance)
        {
            _context.Maintenances.Add(maintenance);
            await _context.SaveChangesAsync();
            return maintenance;
        }

        public async Task<Maintenance> UpdateMaintenanceAsync(Maintenance maintenance)
        {
            _context.Entry(maintenance).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return maintenance;
        }

        public async Task<bool> DeleteMaintenanceAsync(Maintenance maintenance)
        {
            _context.Maintenances.Remove(maintenance);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
