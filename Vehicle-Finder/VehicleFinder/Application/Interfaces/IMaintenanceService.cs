using Domain.Entities;

namespace VehicleFinder.Application.Interfaces
{
    public interface IMaintenanceService
    {
        Task<IEnumerable<Maintenance>> GetAllMaintenancesAsync();
        Task<Maintenance> GetMaintenanceByIdAsync(Guid id);
        Task<Maintenance> AddMaintenanceAsync(Maintenance maintenance);
        Task<Maintenance> UpdateMaintenanceAsync(Guid id, Maintenance maintenance);
        Task<bool> DeleteMaintenanceAsync(Guid id);

    }
}
