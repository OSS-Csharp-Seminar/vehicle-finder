using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public interface IMaintenanceRepository
    {
        Task<IEnumerable<Maintenance>> GetAllMaintenancesAsync();
        Task<Maintenance> GetMaintenanceByIdAsync(Guid id);
        Task<Maintenance> AddMaintenanceAsync(Maintenance maintenance);
        Task<Maintenance> UpdateMaintenanceAsync(Maintenance maintenance);
        Task<bool> DeleteMaintenanceAsync(Maintenance maintenance);
    }
}
